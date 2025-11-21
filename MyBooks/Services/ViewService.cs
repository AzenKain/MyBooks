using Microsoft.Web.WebView2.WinForms;
using MyBooks.DTOs;
using System.Text;
using System.Text.Json;
using System.Text.RegularExpressions;
using VersOne.Epub;

namespace MyBooks.Services
{
    public class ViewService
    {

        public async Task<ServiceResponse<bool>> ViewFileAsync(string filePath)
        {
            string extension = Path.GetExtension(filePath).ToLowerInvariant();
            var response = new ServiceResponse<bool>();
            try
            {
                bool dto = false;
                if (extension == ".epub")
                {
                    await ViewEpub(filePath);
                    dto = true;
                }
                else if (extension == ".pdf")
                {
                    await ViewPdf(filePath);
                    dto = true;
                }
                else
                {
                    response.Success = false;
                    response.Message = "Unsupported file format.";
                    return response;
                }
                response.Success = true;
                response.Data = dto;
            }
            catch (Exception ex)
            {
                response.Success = false;
                response.Message = $"Error view metadata: {ex.Message}";
            }

            return response;
        }

        private async Task ViewPdf(string pdfPath)
        {
            if (!File.Exists(pdfPath))
            {
                MessageBox.Show($"Lỗi: Không tìm thấy file PDF tại đường dẫn:\n{pdfPath}", "Lỗi File", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            Form pdfForm = new Form
            {
                Width = 800,
                Height = 600,
                Text = Path.GetFileName(pdfPath)
            };

            var webView = new WebView2 { Dock = DockStyle.Fill };
            pdfForm.Controls.Add(webView);

            try
            {
                await webView.EnsureCoreWebView2Async();

                webView.CoreWebView2.Navigate(new Uri(pdfPath).AbsoluteUri);

                pdfForm.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi tải WebView2 hoặc file PDF:\n{ex.Message}", "Lỗi WebView2", MessageBoxButtons.OK, MessageBoxIcon.Error);
                pdfForm.Dispose();
            }
        }

        private static string NormalizeEpubPath(string path)
        {
            path = path.Replace('\\', '/');
            var segments = path.Split(new char[] { '/' }, StringSplitOptions.RemoveEmptyEntries);
            var stack = new Stack<string>();

            foreach (var segment in segments)
            {
                if (segment == "." || segment == "")
                {
                    continue;
                }
                else if (segment == "..")
                {
                    if (stack.Count > 0)
                    {
                        stack.Pop();
                    }
                }
                else
                {
                    stack.Push(segment);
                }
            }

            return string.Join("/", stack.Reverse());
        }

        private string GenerateTableOfContentsScript(List<EpubNavigationItem>? tocItems)
        {
            var jsBuilder = new StringBuilder();
            jsBuilder.AppendLine("const tocDiv = document.getElementById('toc-content');");
            jsBuilder.AppendLine("const sidebar = document.getElementById('toc-sidebar');");
            jsBuilder.AppendLine("const toggleBtn = document.getElementById('toggle-btn');");

            jsBuilder.AppendLine("let globalChapterIndex = 0;");

            jsBuilder.AppendLine("function createToc(items, parentElement) {");
            jsBuilder.AppendLine("  let list = document.createElement('ul');");
            jsBuilder.AppendLine("  parentElement.appendChild(list);");

            jsBuilder.AppendLine("  for (let i = 0; i < items.length; i++) {");
            jsBuilder.AppendLine("    const item = items[i];");
            jsBuilder.AppendLine("    const li = document.createElement('li');");

            jsBuilder.AppendLine("    const spanIcon = document.createElement('span');");
            jsBuilder.AppendLine("    spanIcon.className = 'toc-icon';");
            jsBuilder.AppendLine("    spanIcon.textContent = (item.NestedItems && item.NestedItems.length > 0) ? '▸' : '•';");

            jsBuilder.AppendLine("    const a = document.createElement('a');");
            jsBuilder.AppendLine("    a.textContent = item.Title;");

            jsBuilder.AppendLine("    a.href = '#chapter-' + globalChapterIndex;");
            jsBuilder.AppendLine("    globalChapterIndex++;");

            jsBuilder.AppendLine("    a.className = 'toc-link';");

            jsBuilder.AppendLine("    li.appendChild(spanIcon);");
            jsBuilder.AppendLine("    li.appendChild(a);");

            jsBuilder.AppendLine("    if (item.NestedItems && item.NestedItems.length > 0) {");
            jsBuilder.AppendLine("      createToc(item.NestedItems, li);");
            jsBuilder.AppendLine("    }");

            jsBuilder.AppendLine("    list.appendChild(li);");
            jsBuilder.AppendLine("  }");
            jsBuilder.AppendLine("}");

            jsBuilder.AppendLine($"const tocData = {JsonSerializer.Serialize(tocItems)};");
            jsBuilder.AppendLine("createToc(tocData, tocDiv);");

            // Toggle sidebar functionality
            jsBuilder.AppendLine(@"
                toggleBtn.addEventListener('click', function() {
                    sidebar.classList.toggle('collapsed');
                    if (sidebar.classList.contains('collapsed')) {
                        toggleBtn.innerHTML = '&gt;';
                    } else {
                        toggleBtn.innerHTML = '&lt;';
                    }
                });

                document.querySelectorAll('.toc-link').forEach(link => {
                    link.addEventListener('click', function(e) {
                        e.preventDefault();
                        const targetId = this.getAttribute('href').substring(1);
                        const targetElement = document.getElementById(targetId);
                        if (targetElement) {
                            targetElement.scrollIntoView({ behavior: 'smooth', block: 'start' });
                    
                            document.querySelectorAll('.toc-link').forEach(l => l.classList.remove('active'));
                            this.classList.add('active');
                        }
                    });
                });
            ");

            return jsBuilder.ToString();
        }

        private async Task ViewEpub(string epubPath)
        {
            EpubBook epub = await EpubReader.ReadBookAsync(epubPath);

            string tempDir = Path.Combine(Path.GetTempPath(), Path.GetFileNameWithoutExtension(epubPath));
            if (Directory.Exists(tempDir)) Directory.Delete(tempDir, true);
            Directory.CreateDirectory(tempDir);

            var cssBuilder = new StringBuilder();

            cssBuilder.AppendLine(@"
                * { box-sizing: border-box; margin: 0; padding: 0; }
        
                body { 
                    font-family: 'Segoe UI', Tahoma, Geneva, Verdana, sans-serif;
                    height: 100vh;
                    overflow: hidden;
                    display: flex;
                    background-color: #ffffff;
                    position: relative;
                }

                /* Sidebar - Fixed, Always Visible */
                #toc-sidebar { 
                    width: 300px;
                    background: linear-gradient(to bottom, #f8f9fa 0%, #e9ecef 100%);
                    border-right: 2px solid #dee2e6;
                    display: flex;
                    flex-direction: column;
                    height: 100vh;
                    position: fixed;
                    left: 0;
                    top: 0;
                    z-index: 1000;
                    transition: transform 0.3s ease;
                }

                #toc-sidebar.collapsed {
                    transform: translateX(-300px);
                }

                #toc-header { 
                    padding: 20px 15px;
                    background: linear-gradient(135deg, #667eea 0%, #764ba2 100%);
                    color: white;
                    font-size: 1.2em;
                    font-weight: 600;
                    letter-spacing: 0.5px;
                    text-align: center;
                    box-shadow: 0 2px 8px rgba(0,0,0,0.1);
                    flex-shrink: 0;
                }

                #toc-content {
                    flex: 1;
                    overflow-y: auto;
                    padding: 15px 10px;
                }

                /* Toggle Button */
                #toggle-btn {
                    position: fixed;
                    left: 300px;
                    top: 50%;
                    transform: translateY(-50%);
                    width: 30px;
                    height: 60px;
                    background: linear-gradient(135deg, #667eea 0%, #764ba2 100%);
                    color: white;
                    border: none;
                    border-radius: 0 8px 8px 0;
                    cursor: pointer;
                    font-size: 18px;
                    font-weight: bold;
                    display: flex;
                    align-items: center;
                    justify-content: center;
                    box-shadow: 2px 0 8px rgba(0,0,0,0.2);
                    z-index: 1001;
                    transition: left 0.3s ease, background 0.2s ease;
                }

                #toc-sidebar.collapsed + #toggle-btn {
                    left: 0;
                }

                #toggle-btn:hover {
                    background: linear-gradient(135deg, #5568d3 0%, #6a3d8f 100%);
                }

                /* Custom Scrollbar */
                #toc-content::-webkit-scrollbar {
                    width: 8px;
                }

                #toc-content::-webkit-scrollbar-track {
                    background: #f1f1f1;
                }

                #toc-content::-webkit-scrollbar-thumb {
                    background: #888;
                    border-radius: 4px;
                }

                #toc-content::-webkit-scrollbar-thumb:hover {
                    background: #555;
                }

                /* TOC Styling */
                #toc-content ul { 
                    list-style: none; 
                    padding-left: 0; 
                    margin: 0;
                }

                #toc-content ul ul {
                    padding-left: 20px;
                    margin-top: 5px;
                }

                #toc-content li { 
                    display: flex;
                    align-items: flex-start;
                    margin: 8px 0;
                    padding: 4px 8px;
                    border-radius: 6px;
                    transition: background-color 0.2s ease;
                }

                #toc-content li:hover {
                    background-color: rgba(102, 126, 234, 0.1);
                }

                .toc-icon { 
                    color: #667eea;
                    font-size: 0.9em;
                    margin-right: 8px;
                    flex-shrink: 0;
                    line-height: 1.4;
                }

                .toc-link { 
                    text-decoration: none;
                    color: #2c3e50;
                    font-size: 0.95em;
                    line-height: 1.4;
                    flex: 1;
                    transition: all 0.2s ease;
                }

                .toc-link:hover { 
                    color: #667eea;
                    font-weight: 500;
                }

                .toc-link.active {
                    color: #667eea;
                    font-weight: 600;
                }

                /* Content Area */
                #content-area { 
                    margin-left: 300px;
                    flex: 1;
                    height: 100vh;
                    overflow-y: auto;
                    padding: 40px 60px;
                    background-color: #ffffff;
                    transition: margin-left 0.3s ease;
                }

                #toc-sidebar.collapsed ~ #content-area {
                    margin-left: 0;
                }

                #content-area::-webkit-scrollbar {
                    width: 10px;
                }

                #content-area::-webkit-scrollbar-track {
                    background: #f1f1f1;
                }

                #content-area::-webkit-scrollbar-thumb {
                    background: #667eea;
                    border-radius: 5px;
                }

                #content-area::-webkit-scrollbar-thumb:hover {
                    background: #5568d3;
                }

                #content-area section { 
                    margin-bottom: 60px;
                    padding: 30px;
                    background: #ffffff;
                    border-radius: 8px;
                    box-shadow: 0 2px 4px rgba(0,0,0,0.05);
                    scroll-margin-top: 20px;
                }

                #content-area h1 { 
                    margin-top: 0;
                    margin-bottom: 20px;
                    color: #2c3e50;
                    font-size: 2em;
                    border-bottom: 3px solid #667eea;
                    padding-bottom: 10px;
                }

                #content-area h2 {
                    color: #34495e;
                    margin-top: 25px;
                    margin-bottom: 15px;
                }

                #content-area p {
                    line-height: 1.8;
                    margin-bottom: 15px;
                    color: #444;
                }

                #content-area img {
                    max-width: 100%;
                    height: auto;
                    border-radius: 4px;
                    box-shadow: 0 2px 8px rgba(0,0,0,0.1);
                    margin: 20px 0;
                }

                /* Responsive */
                @media (max-width: 768px) {
                    #toc-sidebar {
                        width: 250px;
                    }
            
                    #toc-sidebar.collapsed {
                        transform: translateX(-250px);
                    }

                    #toggle-btn {
                        left: 250px;
                    }

                    #toc-sidebar.collapsed + #toggle-btn {
                        left: 0;
                    }
            
                    #content-area {
                        margin-left: 250px;
                        padding: 20px;
                    }

                    #toc-sidebar.collapsed ~ #content-area {
                        margin-left: 0;
                    }
                }
            ");

            foreach (var cssFile in epub.Content.Css.Local)
            {
                cssBuilder.AppendLine(cssFile.Content);
            }
            string inlineCss = $"<style>{cssBuilder}</style>";

            var imageBase64Map = new Dictionary<string, string>();
            foreach (var imageFile in epub.Content.Images.Local)
            {
                string base64String = Convert.ToBase64String(imageFile.Content);
                string mimeType = imageFile.ContentMimeType ?? "image/jpeg";
                string dataUrl = $"data:{mimeType};base64,{base64String}";

                imageBase64Map.Add(imageFile.FilePath, dataUrl);
            }

            var finalHtmlBuilder = new StringBuilder();
            finalHtmlBuilder.AppendLine("<!DOCTYPE html><html><head><meta charset='utf-8'>");
            finalHtmlBuilder.AppendLine(inlineCss);
            finalHtmlBuilder.AppendLine("</head><body>");

            finalHtmlBuilder.AppendLine("<div id='toc-sidebar'>");
            finalHtmlBuilder.AppendLine("<div id='toc-header'>MỤC LỤC</div>");
            finalHtmlBuilder.AppendLine("<div id='toc-content'></div>");
            finalHtmlBuilder.AppendLine("</div>");

            finalHtmlBuilder.AppendLine("<button id='toggle-btn'>&lt;</button>");

            finalHtmlBuilder.AppendLine("<div id='content-area'>");

            const string ImageRegexPattern = @"<(?:img|image)[^>]*?(src|xlink:href)=[""']([^""']+)[""'][^>]*?>";

            int chapterIndex = 0;
            foreach (var chapter in epub.ReadingOrder)
            {
                string chapterContent = chapter.Content;

                string sectionId = $"chapter-{chapterIndex++}";
                finalHtmlBuilder.AppendLine($"<section id='{sectionId}'>");

                string chapterDir = Path.GetDirectoryName(chapter.FilePath)?.Replace('\\', '/') ?? string.Empty;

                chapterContent = Regex.Replace(chapterContent,
                    ImageRegexPattern,
                    (match) => {
                        string attributeName = match.Groups[1].Value;
                        string src = match.Groups[2].Value;

                        string decodedSrc = Uri.UnescapeDataString(src);

                        string combinedPath = Path.Combine(chapterDir, decodedSrc).Replace('\\', '/');
                        string canonicalPath = NormalizeEpubPath(combinedPath);

                        if (imageBase64Map.TryGetValue(canonicalPath, out string? base64DataUrl))
                        {
                            return match.Value.Replace(src, base64DataUrl);
                        }

                        return match.Value;
                    },
                    RegexOptions.IgnoreCase | RegexOptions.Singleline
                );

                finalHtmlBuilder.AppendLine(chapterContent);
                finalHtmlBuilder.AppendLine("</section>");
            }

            finalHtmlBuilder.AppendLine("</div>");

            string tocJs = GenerateTableOfContentsScript(epub.Navigation ?? new List<EpubNavigationItem>());
            finalHtmlBuilder.AppendLine($"<script>{tocJs}</script>");

            finalHtmlBuilder.AppendLine("</body></html>");

            string indexPath = Path.Combine(tempDir, "index.html");
            File.WriteAllText(indexPath, finalHtmlBuilder.ToString(), Encoding.UTF8);

            Form epubForm = new Form { Width = 1200, Height = 800, Text = Path.GetFileName(epubPath) };
            var webView = new WebView2 { Dock = DockStyle.Fill };
            epubForm.Controls.Add(webView);

            await webView.EnsureCoreWebView2Async();
            webView.CoreWebView2.Navigate(new Uri(indexPath).AbsoluteUri);

            epubForm.Show();
        }
    }
}
