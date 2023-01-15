using AutoMapper;
using InformsISG.Core.Utilities.Results;
using InformsISG.Core.Utilities.Results.Abstract;
using InformsISG.Core.Utilities.Results.Concrete;
using InformsISG.Data.Abstract;
using InformsISG.Entities.Concrete;
using InformsISG.Entities.Dtos;
using InformsISG.Services.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace InformsISG.Services.Concrete
{
    public class Yaralanma_SekliManager : IYaralanma_SekliService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public Yaralanma_SekliManager(IUnitOfWork unitOfWork,IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task<IResult> AddAsync(Yaralanma_SekliDTO addObject, long createdByUserId)
        {
            var exist =await _unitOfWork.yaralanma_SekliRepository.AnyAsync(x => x.Yaralanma_Sekli_Ad == addObject.Yaralanma_Sekli_Ad);
            if (exist == false)
            {
                var result = _mapper.Map<Yaralanma_Sekli>(addObject);
                DateTime dateTime = DateTime.Now;
                result.Kullanici_Id = createdByUserId;
                result.Yaratilma_Tarihi = dateTime;
                result.Degistirilme_Tarihi = dateTime;
                await _unitOfWork.yaralanma_SekliRepository.AddAsync(result);
                await _unitOfWork.SaveAsync();
                return new Result(ResultStatus.Success, $"{result.Yaralanma_Sekli_Ad} başarılı bir şekilde eklenmiştir.");
            }
            else
            {
                return new Result(ResultStatus.Error, $"{addObject.Yaralanma_Sekli_Ad} zaten kayıtlıdır. Lütfen kontrol edip tekrar deneyiniz.");
            }
        }

        public async Task<IResult> UpdateAsync(Yaralanma_SekliDTO updateObject, long modifiedByUserId)
        {

            var exist = await _unitOfWork.yaralanma_SekliRepository.GetAsync(x => x.Yaralanma_Sekli_Ad == updateObject.Yaralanma_Sekli_Ad);
            if (exist != null)
            {
                var resultObject = await _unitOfWork.yaralanma_SekliRepository.GetAsync(x => x.Id == updateObject.Id);
                if (resultObject != null)
                {
                 var result = _mapper.Map<Yaralanma_SekliDTO, Yaralanma_Sekli>(updateObject, resultObject);
                 DateTime dateTime = DateTime.Now;
                result.Kullanici_Id = modifiedByUserId;
                result.Degistirilme_Tarihi = dateTime;
                await _unitOfWork.yaralanma_SekliRepository.UpdateAsync(result);
                await _unitOfWork.SaveAsync();
                return new Result(ResultStatus.Success, $"{result.Yaralanma_Sekli_Ad} başarılı bir şekilde Güncellenmiştir.");
                }
                else
                {
                    return new Result(ResultStatus.Error, $"{updateObject.Yaralanma_Sekli_Ad} bulunamadı.");
                }
            }
            else
            {
                return new Result(ResultStatus.Error, $"{updateObject.Yaralanma_Sekli_Ad} zaten kayıtlıdır. Lütfen tekrar deneyiniz. ");
            }
        }

        public async Task<IResult> HardDeleteAsync(long Id)
        {
            var deleteObject = await _unitOfWork.yaralanma_SekliRepository.GetAsync(x => x.Id == Id);
            if (deleteObject != null)
            {

                await _unitOfWork.yaralanma_SekliRepository.RemoveAsync(deleteObject);
                await _unitOfWork.SaveAsync();
                return new Result(ResultStatus.Success, $"{deleteObject.Yaralanma_Sekli_Ad} veritabanından başarılı bir şekilde silinmiştir.");
            }
            return new Result(ResultStatus.Error, $"{deleteObject.Yaralanma_Sekli_Ad} bulunamadı.");
        }

        public async Task<IResult> DeleteAsync(long Id, long deletedByUserId)
        {
            var deleteObject = await _unitOfWork.yaralanma_SekliRepository.GetAsync(x => x.Id == Id);
            if (deleteObject != null)
            {
                deleteObject.isDeleted = true;
                deleteObject.Degistirilme_Tarihi = DateTime.Now;
                deleteObject.Kullanici_Id = deletedByUserId;
                await _unitOfWork.yaralanma_SekliRepository.UpdateAsync(deleteObject);
                await _unitOfWork.SaveAsync();
                return new Result(ResultStatus.Success, $"{deleteObject.Yaralanma_Sekli_Ad} başarılı bir şekilde silinmiştir.");
            }
            return new Result(ResultStatus.Error, $"{deleteObject.Yaralanma_Sekli_Ad} bulunamadı.");
        }

        public async Task<IDataResult<IList<Yaralanma_SekliDTO>>> GetAllAsync()
        {
            var resultObject = await _unitOfWork.yaralanma_SekliRepository.GetAllAsync(x => x.isActive && !x.isDeleted);
            if (resultObject.Count >= 0)
            {
                var result = _mapper.Map<IList<Yaralanma_SekliDTO>>(resultObject);
                return new DataResult<IList<Yaralanma_SekliDTO>>(ResultStatus.Success, result);
            }
            return new DataResult<IList<Yaralanma_SekliDTO>>(ResultStatus.Error, "Aradığınız kriterlere uygun veri bulunamadı",
            null);
        }

        public async Task<IDataResult<Yaralanma_SekliDTO>> GetAsync(long Id)
        {
            var resultObject = await _unitOfWork.yaralanma_SekliRepository.GetAsync(x => x.Id == Id);
            if (resultObject != null)
            {
                var result = _mapper.Map<Yaralanma_SekliDTO>(resultObject);
                return new DataResult<Yaralanma_SekliDTO>(ResultStatus.Success, result);
            }
            return new DataResult<Yaralanma_SekliDTO>(ResultStatus.Error, "Aradığınız kriterlere uygun veri bulunamadı",
            null);
        }



  
    }
}
