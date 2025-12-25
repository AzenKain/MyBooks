using MyBooks.Data;
using MyBooks.DTOs;
using MyBooks.Models;
using MyBooks.State;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBooks.Services
{


    public class AuthService
    {
        private readonly ProfileRepository profileRepository = new ProfileRepository();
        private readonly SettingRepository settingRepository = new SettingRepository();
        private readonly BookProfileRepository bookProfileRepository = new BookProfileRepository();
        private readonly BookService bookService = new BookService();
        public AuthService()
        {
            var profile = GetCurrentProfile();
            AppStore.Update(state => state with
            {
                Setting = state.Setting with
                {
                    currentProfile = profile
                }
            });
        }

        public Profile GetCurrentProfile()
        {
            var setting = settingRepository.GetCurrentSetting();
            if (setting == null)
            {
                var profileId = profileRepository.Insert(new Profile { ProfileName = "Default" });
                var newSetting = new Setting
                {
                    CurrentProfile = profileId
                };
                settingRepository.Insert(newSetting);

                return profileRepository.GetById(profileId)
                    ?? throw new InvalidOperationException("Failed to create default profile.");
            }

            var profile = profileRepository.GetById(setting.CurrentProfile);

            if (profile == null)
            {
                var profileId = profileRepository.Insert(new Profile { ProfileName = "Default" });
                setting.CurrentProfile = profileId;
                settingRepository.Update(setting);

                profile = profileRepository.GetById(profileId)
                    ?? throw new InvalidOperationException("Failed to create default profile.");
            }

            return profile;
        }

        
        public List<Profile> GetAllProfiles()
        {
            return profileRepository.GetAll().ToList();
        }

        public ServiceResponse<Profile> SwitchProfile(int profileId)
        {
            var profile = profileRepository.GetById(profileId);
            if (profile == null)
            {
                return new ServiceResponse<Profile>
                {
                    Success = false,
                    Message = "Profile not found.",
                    Data = null
                };
            }
            var setting = settingRepository.GetCurrentSetting();
            setting.CurrentProfile = profileId;
            settingRepository.Update(setting);
            AppStore.Update(state => state with
            {
                Setting = state.Setting with
                {
                    currentProfile = profile
                }
            });
            bookService.UpdateBookCacheList();
            return new ServiceResponse<Profile>
            {
                Success = true,
                Message = "Profile switched successfully.",
                Data = profile
            };
        }


        public ServiceResponse<Profile> CreateProfile(string profileName)
        {
            var newProfile = new Profile
            {
                ProfileName = profileName
            };
            var insertedProfileId = profileRepository.Insert(newProfile);
            var insertedProfile = profileRepository.GetById(insertedProfileId);
            return new ServiceResponse<Profile>
            {
                Success = true,
                Message = "Profile created successfully.",
                Data = insertedProfile
            };
        }

        public ServiceResponse<Profile> UpdateProfile(int profileId, string profileName)
        {
            var profile = profileRepository.GetById(profileId);
            if (profile == null)
            {
                return new ServiceResponse<Profile>
                {
                    Success = false,
                    Message = "Profile not found.",
                    Data = null
                };
            }
            profile.ProfileName = profileName;
            profileRepository.Update(profile);
            var updatedProfile = profileRepository.GetById(profileId);
            return new ServiceResponse<Profile>
            {
                Success = true,
                Message = "Profile updated successfully.",
                Data = updatedProfile
            };
        }

        public ServiceResponse<Boolean> DeleleProfile(int profileId)
        {
            var profile = profileRepository.GetById(profileId);
            if (profile == null)
            {
                return new ServiceResponse<Boolean>
                {
                    Success = false,
                    Message = "Profile not found.",
                    Data = false
                };
            }

            if (profileRepository.GetAll().Count() <= 1)
            {
                return new ServiceResponse<Boolean>
                {
                    Success = false,
                    Message = "Cannot delete the only profile.",
                    Data = false
                };
            }
      
            profileRepository.Delete(profileId);
            var listBookIds = bookProfileRepository.GetBookIdsByProfileid(profileId);
            foreach (var bookId in listBookIds)
            {
                bookService.DeleteABook(bookId);
            }
            bookProfileRepository.RemoveAllBooksFromProfile(profileId);

            var setting = settingRepository.GetCurrentSetting();
            if (setting.CurrentProfile == profileId)
            {
                var defaultProfile = profileRepository.GetDefaultProfile();
                if (defaultProfile != null) {
                    setting.CurrentProfile = defaultProfile.Id;
                    settingRepository.Update(setting);
                } else {
                    var newDefaultProfile = profileRepository.Insert(new Profile { ProfileName = "Default" });
                    setting.CurrentProfile = newDefaultProfile;
                    settingRepository.Update(setting);
                    defaultProfile = profileRepository.GetById(newDefaultProfile) ?? throw new InvalidOperationException("Failed to create default profile.");
                }
                AppStore.Update(state => state with
                {
                    Setting = state.Setting with
                    {
                        currentProfile = defaultProfile
                    }
                });

                bookService.UpdateBookCacheList();
            }

            return new ServiceResponse<Boolean>
            {
                Success = true,
                Message = "Profile deleted successfully.",
                Data = true
            };
        }

    }
}