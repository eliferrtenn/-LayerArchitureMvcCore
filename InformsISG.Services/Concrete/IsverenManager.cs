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
    public class IsverenManager : IIsverenService
    {

        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public IsverenManager(IUnitOfWork unitOfWork,IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task<IResult> AddAsync(IsverenDTO addObject, long createdByUserId)
        {
            var exist =await  _unitOfWork.isverenRepository.AnyAsync(x => x.Isveren_Ad == addObject.Isveren_Ad);
            if (exist == false)
            {
                var result = _mapper.Map<Isveren>(addObject);
                DateTime dateTime = DateTime.Now;
                result.Kullanici_Id = createdByUserId;
                result.Yaratilma_Tarihi = dateTime;
                result.Degistirilme_Tarihi = dateTime;
                await _unitOfWork.isverenRepository.AddAsync(result);
                await _unitOfWork.SaveAsync();
                return new Result(ResultStatus.Success, $"{result.Isveren_Ad} başarılı bir şekilde eklenmiştir.");
            }
            else
            {
                return new Result(ResultStatus.Error, $"{addObject.Isveren_Ad} zaten kayıtlıdır. Lütfen kontrol edip tekrar deneyiniz.");
            }
        }

        public async Task<IResult> DeleteAsync(long Id, long deletedByUserId)
        {
            var deleteObject = await _unitOfWork.isverenRepository.GetAsync(x => x.Id == Id);
            if (deleteObject != null)
            {
                deleteObject.isDeleted = true;
                deleteObject.Degistirilme_Tarihi = DateTime.Now;
                deleteObject.Kullanici_Id = deletedByUserId;
                await _unitOfWork.isverenRepository.UpdateAsync(deleteObject);
                await _unitOfWork.SaveAsync();
                return new Result(ResultStatus.Success, $"{deleteObject.Isveren_Ad} kişisi başarılı bir şekilde silinmiştir.");
            }
            return new Result(ResultStatus.Error, $"{deleteObject.Isveren_Ad} kişisi bulunamadı.");
        }

        public async Task<IDataResult<IList<IsverenDTO>>> GetAllAsync()
        {
            var resultObject = await _unitOfWork.isverenRepository.GetAllAsync(x => x.isActive && !x.isDeleted);
            if (resultObject.Count >= 0)
            {
                var result = _mapper.Map<IList<IsverenDTO>>(resultObject);
                return new DataResult<IList<IsverenDTO>>(ResultStatus.Success, result);
            }
            return new DataResult<IList<IsverenDTO>>(ResultStatus.Error, "Aradığınız kriterlere uygun veri bulunamadı",
            null);
        }

        public async Task<IDataResult<IsverenDTO>> GetAsync(long Id)
        {
            var resultObject = await _unitOfWork.isverenRepository.GetAsync(x => x.Id == Id);
            if (resultObject != null)
            {
                var result = _mapper.Map<IsverenDTO>(resultObject);
                return new DataResult<IsverenDTO>(ResultStatus.Success, result);
            }
            return new DataResult<IsverenDTO>(ResultStatus.Error, "Aradığınız kriterlere uygun veri bulunamadı",
            null);
        }

        public async Task<IResult> HardDeleteAsync(long Id)
        {
            var deleteObject = await _unitOfWork.isverenRepository.GetAsync(x => x.Id == Id);
            if (deleteObject != null)
            {

                await _unitOfWork.isverenRepository.RemoveAsync(deleteObject);
                await _unitOfWork.SaveAsync();
                return new Result(ResultStatus.Success, $"{deleteObject.Isveren_Ad} kişisi veritabanından başarılı bir şekilde silinmiştir.");
            }
            return new Result(ResultStatus.Error, $"{deleteObject.Isveren_Ad} kişisi bulunamadı.");
        }

        public async Task<IResult> UpdateAsync(IsverenDTO updateObject, long modifiedByUserId)
        {
            var exist = await _unitOfWork.isverenRepository.AnyAsync(x => x.Isveren_Ad == updateObject.Isveren_Ad && x.Id != updateObject.Id);
            if (exist == false)
            {
            var resultObject = await _unitOfWork.isverenRepository.GetAsync(x => x.Id == updateObject.Id);
            if (resultObject != null)
            {
                var result = _mapper.Map<IsverenDTO,Isveren>(updateObject,resultObject);
                DateTime dateTime = DateTime.Now;
                result.Kullanici_Id = modifiedByUserId;
                result.Degistirilme_Tarihi = dateTime;
                await _unitOfWork.isverenRepository.UpdateAsync(result);
                await _unitOfWork.SaveAsync();
                return new Result(ResultStatus.Success, $"{result.Isveren_Ad} başarılı bir şekilde Güncellenmiştir.");
            }
            else
            {
                return new Result(ResultStatus.Error, $"{updateObject.Isveren_Ad} bulunamadı.");
            }
            }
            else
            {
                return new Result(ResultStatus.Error, $"{updateObject.Isveren_Ad} zaten kayıtlıdır. Lütfen kontrol edip tekrar deneyiniz.");
            }
        }
    }
}
