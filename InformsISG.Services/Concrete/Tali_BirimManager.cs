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
    public class Tali_BirimManager : ITali_BirimService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public Tali_BirimManager(IUnitOfWork unitOfWork,IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task<IResult> AddAsync(Tali_BirimDTO addObject, long createdByUserId)
        {
            var exist =await _unitOfWork.tali_BirimRepository.AnyAsync(x => x.Tali_Birim_Ad == addObject.Tali_Birim_Ad);
            if (exist == false)
            {
                var result = _mapper.Map<Tali_Birim>(addObject);
                DateTime dateTime = DateTime.Now;
                result.Kullanici_Id = createdByUserId;
                result.Yaratilma_Tarihi = dateTime;
                result.Degistirilme_Tarihi = dateTime;
                await _unitOfWork.tali_BirimRepository.AddAsync(result);
                await _unitOfWork.SaveAsync();
                return new Result(ResultStatus.Success, $"{result.Tali_Birim_Ad} başarılı bir şekilde eklenmiştir.");
            }
            else
            {
                return new Result(ResultStatus.Error, $"{addObject.Tali_Birim_Ad} zaten kayıtlıdır. Lütfen kontrol edip tekrar deneyiniz.");
            }
        }

        public async Task<IResult> UpdateAsync(Tali_BirimDTO updateObject, long modifiedByUserId)
        {
            var exist = await _unitOfWork.tali_BirimRepository.AnyAsync(x => x.Tali_Birim_Ad == updateObject.Tali_Birim_Ad && x.Id != updateObject.Id);

            if (exist == false)
            {
                var resultObject = await _unitOfWork.tali_BirimRepository.GetAsync(x => x.Id == updateObject.Id);
                if (resultObject != null)
                {
                    var result = _mapper.Map<Tali_BirimDTO,Tali_Birim>(updateObject,resultObject);
                    DateTime dateTime = DateTime.Now;
                    result.Kullanici_Id = modifiedByUserId;
                    result.Degistirilme_Tarihi = dateTime;
                    await _unitOfWork.tali_BirimRepository.UpdateAsync(result);
                    await _unitOfWork.SaveAsync();
                    return new Result(ResultStatus.Success, $"{result.Tali_Birim_Ad} başarılı bir şekilde Güncellenmiştir.");
                }
                else
                {
                    return new Result(ResultStatus.Error, $"{updateObject.Tali_Birim_Ad} bulunamadı.");
                }
            }
            else
            {
                return new Result(ResultStatus.Error, $"{updateObject.Tali_Birim_Ad} zaten kayıtlıdır. Lütfen kontrol edip tekrar deneyiniz.");
            }
        }

        public async Task<IResult> HardDeleteAsync(long Id)
        {
            var deleteObject = await _unitOfWork.tali_BirimRepository.GetAsync(x => x.Id == Id);
            if (deleteObject != null)
            {
                await _unitOfWork.tali_BirimRepository.RemoveAsync(deleteObject);
                await _unitOfWork.SaveAsync();
                return new Result(ResultStatus.Success, $"{deleteObject.Tali_Birim_Ad} veritabanından başarılı bir şekilde silinmiştir.");
            }
            return new Result(ResultStatus.Error, $"{deleteObject.Tali_Birim_Ad} bulunamadı.");
        }

        public async Task<IResult> DeleteAsync(long Id, long deletedByUserId)
        {
            var deleteObject = await _unitOfWork.tali_BirimRepository.GetAsync(x => x.Id == Id);
            if (deleteObject != null)
            {
                deleteObject.isDeleted = true;
                deleteObject.Degistirilme_Tarihi = DateTime.Now;
                deleteObject.Kullanici_Id = deletedByUserId;
                await _unitOfWork.tali_BirimRepository.UpdateAsync(deleteObject);
                await _unitOfWork.SaveAsync();
                return new Result(ResultStatus.Success, $"{deleteObject.Tali_Birim_Ad} başarılı bir şekilde silinmiştir.");
            }
            return new Result(ResultStatus.Error, $"{deleteObject.Tali_Birim_Ad} bulunamadı.");
        }

        public async Task<IDataResult<IList<Tali_BirimDTO>>> GetAllAsync(long Id)
        {
            var resultObject = await _unitOfWork.tali_BirimRepository.GetAllAsync(x => x.isActive && !x.isDeleted && x.Birim_Id==Id);
            if (resultObject.Count >= 0)
            {
                var result = _mapper.Map<IList<Tali_BirimDTO>>(resultObject);
                return new DataResult<IList<Tali_BirimDTO>>(ResultStatus.Success, result);
            }
            return new DataResult<IList<Tali_BirimDTO>>(ResultStatus.Error, "Aradığınız kriterlere uygun veri bulunamadı",
            null);
        }


        public async Task<IDataResult<IList<Tali_BirimDTO>>> GetAllAsyncTum()
        {
            var resultObject = await _unitOfWork.tali_BirimRepository.GetAllAsync(x => x.isActive && !x.isDeleted);
            if (resultObject.Count >= 0)
            {
                var result = _mapper.Map<IList<Tali_BirimDTO>>(resultObject);
                return new DataResult<IList<Tali_BirimDTO>>(ResultStatus.Success, result);
            }
            return new DataResult<IList<Tali_BirimDTO>>(ResultStatus.Error, "Aradığınız kriterlere uygun veri bulunamadı",
            null);
        }


        public async Task<IDataResult<Tali_BirimDTO>> GetAsync(long Id)
        {
            var resultObject = await _unitOfWork.tali_BirimRepository.GetAsync(x => x.Id == Id);
            if (resultObject != null)
            {
                var result = _mapper.Map<Tali_BirimDTO>(resultObject);
                return new DataResult<Tali_BirimDTO>(ResultStatus.Success, result);
            }
            return new DataResult<Tali_BirimDTO>(ResultStatus.Error, "Aradığınız kriterlere uygun veri bulunamadı",
            null);
        }

        public async Task<IDataResult<IList<Tali_BirimDTO>>> GetAllTaliBirim(int id)
        {
            var resultObject = await _unitOfWork.tali_BirimRepository.GetAllAsync(x => x.Birim_Id == id && !x.isDeleted);
            if (resultObject.Count > -1)
            {
                var result = _mapper.Map<IList<Tali_BirimDTO>>(resultObject);

                return new DataResult<IList<Tali_BirimDTO>>(ResultStatus.Success, result);
            }
            return new DataResult<IList<Tali_BirimDTO>>(ResultStatus.Error, "Aradığınız kriterlere uygun veri bulunamadı.", null);
        }




    }
}
