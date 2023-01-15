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
    public class Risk_KategoriManager : IRisk_KategoriService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public Risk_KategoriManager(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task<IResult> AddAsync(Risk_KategoriDTO addObject, long createdByUserId)
        {
            var exist = await _unitOfWork.risk_KategoriRepository.AnyAsync(x => x.Risk_Kategori_Ad == addObject.Risk_Kategori_Ad);
            if (exist == false)
            {
                var result = _mapper.Map<Risk_Kategori>(addObject);
                DateTime dateTime = DateTime.Now;
                result.Kullanici_Id = createdByUserId;
                result.Yaratilma_Tarihi = dateTime;
                result.Degistirilme_Tarihi = dateTime;
                await _unitOfWork.risk_KategoriRepository.AddAsync(result);
                await _unitOfWork.SaveAsync();
                return new Result(ResultStatus.Success, $"{result.Risk_Kategori_Ad} başarılı bir şekilde eklenmiştir.");
            }
            else
            {
                return new Result(ResultStatus.Error, $"{addObject.Risk_Kategori_Ad} zaten kayıtlıdır. Lütfen kontrol edip tekrar deneyiniz.");
            }
        }

        public async Task<IResult> DeleteAsync(long Id, long deletedByUserId)
        {
            var deleteObject = await _unitOfWork.risk_KategoriRepository.GetAsync(x => x.Id == Id);
            if (deleteObject != null)
            {
                deleteObject.isDeleted = true;
                deleteObject.Degistirilme_Tarihi = DateTime.Now;
                deleteObject.Kullanici_Id = deletedByUserId;
                await _unitOfWork.risk_KategoriRepository.UpdateAsync(deleteObject);
                await _unitOfWork.SaveAsync();
                return new Result(ResultStatus.Success, $"{deleteObject.Risk_Kategori_Ad} başarılı bir şekilde silinmiştir.");
            }
            return new Result(ResultStatus.Error, $"{deleteObject.Risk_Kategori_Ad} bulunamadı.");
        }

        public async Task<IDataResult<IList<Risk_KategoriDTO>>> GetAllAsync()
        {
            var resultObject = await _unitOfWork.risk_KategoriRepository.GetAllAsync(x => x.isActive && !x.isDeleted);
            if (resultObject.Count >= 0)
            {
                var result = _mapper.Map<IList<Risk_KategoriDTO>>(resultObject);
                return new DataResult<IList<Risk_KategoriDTO>>(ResultStatus.Success, result);
            }
            return new DataResult<IList<Risk_KategoriDTO>>(ResultStatus.Error, "Aradığınız kriterlere uygun veri bulunamadı",
            null);
        }

        public async Task<IDataResult<Risk_KategoriDTO>> GetAsync(long Id)
        {
            var resultObject = await _unitOfWork.risk_KategoriRepository.GetAsync(x => x.Id == Id);
            if (resultObject != null)
            {
                var result = _mapper.Map<Risk_KategoriDTO>(resultObject);
                return new DataResult<Risk_KategoriDTO>(ResultStatus.Success, result);
            }
            return new DataResult<Risk_KategoriDTO>(ResultStatus.Error, "Aradığınız kriterlere uygun veri bulunamadı",
            null);
        }

        public async Task<IResult> HardDeleteAsync(long Id)
        {
            var deleteObject = await _unitOfWork.risk_KategoriRepository.GetAsync(x => x.Id == Id);
            if (deleteObject != null)
            {

                await _unitOfWork.risk_KategoriRepository.RemoveAsync(deleteObject);
                await _unitOfWork.SaveAsync();
                return new Result(ResultStatus.Success, $"{deleteObject.Risk_Kategori_Ad} veritabanından başarılı bir şekilde silinmiştir.");
            }
            return new Result(ResultStatus.Error, $"{deleteObject.Risk_Kategori_Ad} bulunamadı.");
        }

        public async Task<IResult> UpdateAsync(Risk_KategoriDTO updateObject, long modifiedByUserId)
        {
            var exist = await _unitOfWork.risk_KategoriRepository.AnyAsync(x => x.Risk_Kategori_Ad == updateObject.Risk_Kategori_Ad && x.Id != updateObject.Id);
            if (exist == false)
            {
                var resultObject = await _unitOfWork.risk_KategoriRepository.GetAsync(x => x.Id == updateObject.Id);
                if (resultObject != null)
                {
                    var result = _mapper.Map<Risk_KategoriDTO, Risk_Kategori>(updateObject, resultObject);
                    DateTime dateTime = DateTime.Now;
                    result.Kullanici_Id = modifiedByUserId;
                    result.Degistirilme_Tarihi = dateTime;
                    await _unitOfWork.risk_KategoriRepository.UpdateAsync(result);
                    await _unitOfWork.SaveAsync();
                    return new Result(ResultStatus.Success, $"{result.Risk_Kategori_Ad} başarılı bir şekilde Güncellenmiştir.");
                }
                else
                {
                    return new Result(ResultStatus.Error, $"{updateObject.Risk_Kategori_Ad} bulunamadı.");
                }
            }
            else
            {
                return new Result(ResultStatus.Error, $"{updateObject.Risk_Kategori_Ad} zaten kayıtlıdır. Lütfen kontrol edip tekrar deneyiniz.");
            }
        }
    }
}
