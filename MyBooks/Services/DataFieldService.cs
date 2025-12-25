using MyBooks.Data;
using MyBooks.DTOs;
using MyBooks.Models;

namespace MyBooks.Services
{
    public class DataFieldService
    {
        private readonly DataFieldRepository dataFieldRepository;
        
        public DataFieldService() { 
            dataFieldRepository = new DataFieldRepository();
        }

        public ServiceResponse<List<DataField>> GetListField(DataFieldType fieldType)
        {
            var response = new ServiceResponse<List<DataField>>();
            try
            {
                var dateFields = dataFieldRepository.GetAllByType(fieldType.ToDbValue());
                var dtoList = dateFields.ToList();
                response.Success = true;
                response.Data = dtoList;
            }
            catch (Exception ex)
            {
                response.Success = false;
                response.Message = $"Error retrieving date fields: {ex.Message}";
            }
            return response;
        }

        public ServiceResponse<List<DataField>> GetLanguages()
        {
            return GetListField(DataFieldType.Languages);
        }

        public ServiceResponse<List<DataField>> GetPublishers()
        {
            return GetListField(DataFieldType.Publishers);
        }

        public ServiceResponse<List<DataField>> GetAuthors()
        {
            return GetListField(DataFieldType.Authors);
        }

        public ServiceResponse<List<DataField>> GetSeries()
        {
            return GetListField(DataFieldType.Series);
        }

        public ServiceResponse<List<DataField>> GetTags()
        {
            return GetListField(DataFieldType.Tags);
        }

        public ServiceResponse<bool> DeleteAField(int fieldId)
        {
            var response = new ServiceResponse<bool>();
            try
            {
                var existingField = dataFieldRepository.GetById(fieldId);
                if (existingField == null)
                {
                    response.Success = false;
                    response.Message = "Field not found.";
                    return response;
                }
                dataFieldRepository.Delete(fieldId);
                response.Success = true;
                response.Data = true;
                response.Message = "Field deleted successfully.";
            }
            catch (Exception ex)
            {
                response.Success = false;
                response.Message = $"Error deleting field: {ex.Message}";
            }
            return response;
        }

        public ServiceResponse<DataField> CreateAField(DataField dto)
        {
            var response = new ServiceResponse<DataField>();
            try
            {
                var existingField = dataFieldRepository.GetByNameAndType(dto.Name, dto.DataType);
                if (existingField != null)
                {
                    response.Success = false;
                    response.Message = "Field with the same name and type already exists.";
                    return response;
                }
                dto.CreatedAt = DateTime.Now;
                dto.UpdatedAt = DateTime.Now;
                int newId = dataFieldRepository.Insert(dto);
                dto.Id = newId;
                response.Success = true;
                response.Data = dto;
                response.Message = "Field created successfully.";
            }
            catch (Exception ex)
            {
                response.Success = false;
                response.Message = $"Error creating field: {ex.Message}";
            }
            return response;
        }

        public ServiceResponse<DataField> UpdateAField(DataField dto)
        {
            var response = new ServiceResponse<DataField>();
            try
            {
                var existingField = dataFieldRepository.GetById(dto.Id);
                if (existingField == null)
                {
                    response.Success = false;
                    response.Message = "Field not found.";
                    return response;
                }
                existingField.Name = dto.Name;
                existingField.UpdatedAt = DateTime.Now;
                dataFieldRepository.Update(existingField);
                response.Success = true;
                response.Data = existingField;
                response.Message = "Field updated successfully.";
            }
            catch (Exception ex)
            {
                response.Success = false;
                response.Message = $"Error updating field: {ex.Message}";
            }
            return response;
        }
    }

}
