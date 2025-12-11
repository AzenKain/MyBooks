using MyBooks.Data;
using MyBooks.DTOs;
using MyBooks.Models;

namespace MyBooks.Services
{
    public class DateFieldService
    {
        private readonly DataFieldRepository dataFieldRepository;
        
        public DateFieldService() { 
            dataFieldRepository = new DataFieldRepository();
        }

        private ServiceResponse<List<DataField>> GetListField(string fieldType)
        {
            var response = new ServiceResponse<List<DataField>>();
            try
            {
                var dateFields = dataFieldRepository.GetAllByType(fieldType);
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
            return GetListField("languages");
        }

        public ServiceResponse<List<DataField>> GetPublishers()
        {
            return GetListField("publishers");
        }

        public ServiceResponse<List<DataField>> GetAuthors()
        {
            return GetListField("authors");
        }

        public ServiceResponse<List<DataField>> GetSeries()
        {
            return GetListField("series");
        }

        public ServiceResponse<List<DataField>> GetTags()
        {
            return GetListField("tags");
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
