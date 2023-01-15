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
    public class Yaralanan_Vucut_BolgesiManager : IYaralanan_Vucut_BolgesiService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public Yaralanan_Vucut_BolgesiManager(IUnitOfWork unitOfWork,IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task<IResult> AddAsync(Yaralanan_Vucut_BolgesiDTO addObject, long createdByUserId)
        {
            var exist =await _unitOfWork.yaralanan_Vucut_BolgesiRepository.AnyAsync(x => x.Yaralanan_Vucut_Bolgesi_Ad == addObject.Yaralanan_Vucut_Bolgesi_Ad);
            if (exist == false)
            {
                var result = _mapper.Map<Yaralanan_Vucut_Bolgesi>(addObject);
                DateTime dateTime = DateTime.Now;
                result.Kullanici_Id = createdByUserId;
                result.Yaratilma_Tarihi = dateTime;
                result.Degistirilme_Tarihi = dateTime;
                await _unitOfWork.yaralanan_Vucut_BolgesiRepository.AddAsync(result);
                await _unitOfWork.SaveAsync();
                return new Result(ResultStatus.Success, $"{result.Yaralanan_Vucut_Bolgesi_Ad} başarılı bir şekilde eklenmiştir.");
            }
            else
            {
                return new Result(ResultStatus.Error, $"{addObject.Yaralanan_Vucut_Bolgesi_Ad} zaten kayıtlıdır. Lütfen kontrol edip tekrar deneyiniz.");
            }
        }

        public async Task<IResult> UpdateAsync(Yaralanan_Vucut_BolgesiDTO updateObject, long modifiedByUserId)
        {

            var exist = await _unitOfWork.yaralanan_Vucut_BolgesiRepository.GetAsync(x => x.Yaralanan_Vucut_Bolgesi_Ad == updateObject.Yaralanan_Vucut_Bolgesi_Ad
             && x.Id != updateObject.Id);
            if (exist != null)
            {
                var resultObject = await _unitOfWork.yaralanan_Vucut_BolgesiRepository.GetAsync(x => x.Id == updateObject.Id);
                if (resultObject != null)
                {
                var result = _mapper.Map<Yaralanan_Vucut_BolgesiDTO,Yaralanan_Vucut_Bolgesi>(updateObject,resultObject);
                DateTime dateTime = DateTime.Now;
                result.Kullanici_Id = modifiedByUserId;
                result.Degistirilme_Tarihi = dateTime;
                await _unitOfWork.yaralanan_Vucut_BolgesiRepository.UpdateAsync(result);
                await _unitOfWork.SaveAsync();
                return new Result(ResultStatus.Success, $"{result.Yaralanan_Vucut_Bolgesi_Ad} başarılı bir şekilde Güncellenmiştir.");
                }
                else
                {
                    return new Result(ResultStatus.Error, $"{updateObject.Yaralanan_Vucut_Bolgesi_Ad} bulunamadı.");
                }
            }
            else
            {
                return new Result(ResultStatus.Error, $"{updateObject.Yaralanan_Vucut_Bolgesi_Ad} zaten kayıtlıdır. Lütfen tekrar deneyiniz.");
            }


        }

        public async Task<IResult> HardDeleteAsync(long Id)
        {
            var deleteObject = await _unitOfWork.yaralanan_Vucut_BolgesiRepository.GetAsync(x => x.Id == Id);
            if (deleteObject != null)
            {
                await _unitOfWork.yaralanan_Vucut_BolgesiRepository.RemoveAsync(deleteObject);
                await _unitOfWork.SaveAsync();
                return new Result(ResultStatus.Success, $"{deleteObject.Yaralanan_Vucut_Bolgesi_Ad} veritabanından başarılı bir şekilde silinmiştir.");
            }
            return new Result(ResultStatus.Error, $"{deleteObject.Yaralanan_Vucut_Bolgesi_Ad} bulunamadı.");
        }
       
        public async Task<IResult> DeleteAsync(long Id, long deletedByUserId)
        {
            var deleteObject = await _unitOfWork.yaralanan_Vucut_BolgesiRepository.GetAsync(x => x.Id == Id);
            if (deleteObject != null)
            {
                deleteObject.isDeleted = true;
                deleteObject.Degistirilme_Tarihi = DateTime.Now;
                deleteObject.Kullanici_Id = deletedByUserId;
                await _unitOfWork.yaralanan_Vucut_BolgesiRepository.UpdateAsync(deleteObject);
                await _unitOfWork.SaveAsync();
                return new Result(ResultStatus.Success, $"{deleteObject.Yaralanan_Vucut_Bolgesi_Ad} başarılı bir şekilde silinmiştir.");
            }
            return new Result(ResultStatus.Error, $"{deleteObject.Yaralanan_Vucut_Bolgesi_Ad} bulunamadı.");
        }

        public async Task<IDataResult<IList<Yaralanan_Vucut_BolgesiDTO>>> GetAllAsync()
        {
            var resultObject = await _unitOfWork.yaralanan_Vucut_BolgesiRepository.GetAllAsync(x => x.isActive && !x.isDeleted);
            if (resultObject.Count >= 0)
            {
                var result = _mapper.Map<IList<Yaralanan_Vucut_BolgesiDTO>>(resultObject);
                return new DataResult<IList<Yaralanan_Vucut_BolgesiDTO>>(ResultStatus.Success, result);
            }
            return new DataResult<IList<Yaralanan_Vucut_BolgesiDTO>>(ResultStatus.Error, "Aradığınız kriterlere uygun veri bulunamadı",
            null);
        }

        public async Task<IDataResult<Yaralanan_Vucut_BolgesiDTO>> GetAsync(long Id)
        {
            var resultObject = await _unitOfWork.yaralanan_Vucut_BolgesiRepository.GetAsync(x => x.Id == Id);
            if (resultObject != null)
            {
                var result = _mapper.Map<Yaralanan_Vucut_BolgesiDTO>(resultObject);
                return new DataResult<Yaralanan_Vucut_BolgesiDTO>(ResultStatus.Success, result);
            }
            return new DataResult<Yaralanan_Vucut_BolgesiDTO>(ResultStatus.Error, "Aradığınız kriterlere uygun veri bulunamadı",
            null);
        }


     
    }
}
