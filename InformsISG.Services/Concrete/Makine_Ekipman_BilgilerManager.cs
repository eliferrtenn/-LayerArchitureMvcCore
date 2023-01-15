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
    public class Makine_Ekipman_BilgilerManager : IMakine_Ekipman_BilgilerService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public Makine_Ekipman_BilgilerManager(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task<IResult> AddAsync(Makine_Ekipman_BilgilerDTO addObject, long createdByUserId)
        {
            //var exist = await _unitOfWork.makine_Ekipman_BilgileriRepository.AnyAsync(x => x.Madde_Ad == addObject.Madde_Ad && !x.isDeleted);
            //if (exist == false)
            //{
                var result = _mapper.Map<Makine_Ekipman_Bilgiler>(addObject);
                DateTime dateTime = DateTime.Now;
                result.Kullanici_Id = createdByUserId;
                result.Yaratilma_Tarihi = dateTime;
                result.Degistirilme_Tarihi = dateTime;
                await _unitOfWork.makine_Ekipman_BilgileriRepository.AddAsync(result);
                await _unitOfWork.SaveAsync();
                return new Result(ResultStatus.Success, $"{result.Madde_Ad} başarılı bir şekilde eklenmiştir.");
            //}
            //else
            //{
            //    return new Result(ResultStatus.Error, $"{addObject.Madde_Ad} zaten kayıtlıdır. Lütfen kontrol edip tekrar deneyiniz.");
            //}
        }

        public async Task<IResult> DeleteAsync(long Id, long deletedByUserId)
        {
            var deleteObject = await _unitOfWork.makine_Ekipman_BilgileriRepository.GetAsync(x => x.Id == Id);
            if (deleteObject != null)
            {
                deleteObject.isDeleted = true;
                deleteObject.Degistirilme_Tarihi = DateTime.Now;
                deleteObject.Kullanici_Id = deletedByUserId;
                await _unitOfWork.makine_Ekipman_BilgileriRepository.UpdateAsync(deleteObject);
                await _unitOfWork.SaveAsync();
                return new Result(ResultStatus.Success, $"{deleteObject.Madde_Ad} başarılı bir şekilde silinmiştir.");
            }
            return new Result(ResultStatus.Error, $"{deleteObject.Madde_Ad} bulunamadı.");
        }

        public async Task<IDataResult<IList<Makine_Ekipman_BilgilerDTO>>> GetAllAsync()
        {
            var resultObject = await _unitOfWork.makine_Ekipman_BilgileriRepository.GetAllAsync(x => x.isActive && !x.isDeleted);
            if (resultObject.Count >= 0)
            {
                var result = _mapper.Map<IList<Makine_Ekipman_BilgilerDTO>>(resultObject);
                return new DataResult<IList<Makine_Ekipman_BilgilerDTO>>(ResultStatus.Success, result);
            }
            return new DataResult<IList<Makine_Ekipman_BilgilerDTO>>(ResultStatus.Error, "Aradığınız kriterlere uygun veri bulunamadı",
            null);
        }


        public async Task<IDataResult<Makine_Ekipman_BilgilerDTO>> GetAsync(long Id)
        {
            var resultObject = await _unitOfWork.makine_Ekipman_BilgileriRepository.GetAsync(x => x.Id == Id);
            if (resultObject != null)
            {
                var result = _mapper.Map<Makine_Ekipman_BilgilerDTO>(resultObject);
                return new DataResult<Makine_Ekipman_BilgilerDTO>(ResultStatus.Success, result);
            }
            return new DataResult<Makine_Ekipman_BilgilerDTO>(ResultStatus.Error, "Aradığınız kriterlere uygun veri bulunamadı",
            null);
        }

        public async Task<IResult> HardDeleteAsync(long Id)
        {
            var deleteObject = await _unitOfWork.makine_Ekipman_BilgileriRepository.GetAsync(x => x.Id == Id);
            if (deleteObject != null)
            {

                await _unitOfWork.makine_Ekipman_BilgileriRepository.RemoveAsync(deleteObject);
                await _unitOfWork.SaveAsync();
                return new Result(ResultStatus.Success, $"{deleteObject.Madde_Ad} veritabanından başarılı bir şekilde silinmiştir.");
            }
            return new Result(ResultStatus.Error, $"{deleteObject.Madde_Ad} bulunamadı.");
        }

        public async Task<IResult> UpdateAsync(Makine_Ekipman_BilgilerDTO updateObject, long modifiedByUserId)
        {
            var exist = await _unitOfWork.makine_Ekipman_BilgileriRepository.AnyAsync(x => x.Madde_Ad == updateObject.Madde_Ad && !x.isDeleted
             && x.Id != updateObject.Id);
            if (exist == false)
            {
                var resultObject = await _unitOfWork.makine_Ekipman_BilgileriRepository.GetAsync(x => x.Id == updateObject.Id);
                if (resultObject != null)
                {
                    var result = _mapper.Map<Makine_Ekipman_BilgilerDTO, Makine_Ekipman_Bilgiler>(updateObject, resultObject);
                    DateTime dateTime = DateTime.Now;
                    result.Kullanici_Id = modifiedByUserId;
                    result.Degistirilme_Tarihi = dateTime;
                    await _unitOfWork.makine_Ekipman_BilgileriRepository.UpdateAsync(result);
                    await _unitOfWork.SaveAsync();
                    return new Result(ResultStatus.Success, $"{resultObject.Madde_Ad} başarılı bir şekilde Güncellenmiştir.");
                }
                else
                {
                    return new Result(ResultStatus.Error, $"{resultObject.Madde_Ad} bulunamadı.");
                }
            }
            else
            {
                return new Result(ResultStatus.Error, $"{updateObject.Madde_Ad} zaten kayıtlıdır. Lütfen kontrol edip tekrar deneyiniz.");
            }
        }


        public async Task<IDataResult<IList<Makine_Ekipman_BilgilerDTO>>> GetAllMakineEkipmanAsync(long Id)
        {
            var resultObject = await _unitOfWork.makine_Ekipman_BilgileriRepository.GetAllAsync(x => x.isActive && !x.isDeleted && x.Makine_Ekipman_Bilgi_Baslik_Id==Id);
            if (resultObject.Count >= 0)
            {
                var result = _mapper.Map<IList<Makine_Ekipman_BilgilerDTO>>(resultObject);
                return new DataResult<IList<Makine_Ekipman_BilgilerDTO>>(ResultStatus.Success, result);
            }
            return new DataResult<IList<Makine_Ekipman_BilgilerDTO>>(ResultStatus.Error, "Aradığınız kriterlere uygun veri bulunamadı",
            null);
        }
    }

}
