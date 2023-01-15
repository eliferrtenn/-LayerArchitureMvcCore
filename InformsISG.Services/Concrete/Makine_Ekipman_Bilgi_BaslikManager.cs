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
    public class Makine_Ekipman_Bilgi_BaslikManager : IMakine_Ekipman_Bilgi_BaslikService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public Makine_Ekipman_Bilgi_BaslikManager(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task<IResult> AddAsync(Makine_Ekipman_Bilgi_BaslikDTO addObject, long createdByUserId)
        {
            //var exist = await _unitOfWork.makine_Ekipman_Bilgi_BaslikRepository.AnyAsync(x => x.Madde_Ad == addObject.Madde_Ad && !x.isDeleted);
            //if (exist == false)
            //{
                var result = _mapper.Map<Makine_Ekipman_Bilgi_Baslik>(addObject);
                DateTime dateTime = DateTime.Now;
                result.Kullanici_Id = createdByUserId;
                result.Yaratilma_Tarihi = dateTime;
                result.Degistirilme_Tarihi = dateTime;
                await _unitOfWork.makine_Ekipman_Bilgi_BaslikRepository.AddAsync(result);
                await _unitOfWork.SaveAsync();
                return new Result(ResultStatus.Success, $"{result.Madde_Ad} başarılı bir şekilde eklenmiştir.");
            //}
            //else
            //{
            //    return new Result(ResultStatus.Error, $"{addObject.Madde_Ad} zaten kayıtlıdır. Lütfen kontrol edip tekrar deneyiniz.");
            //}
        }

        public async Task<IDataResult<Makine_Ekipman_Bilgi_BaslikDTO>> AddAndGetAsync(Makine_Ekipman_Bilgi_BaslikDTO addObject, long createdByUserId)
        {
            //var exist = await _unitOfWork.makine_Ekipman_Bilgi_BaslikRepository.AnyAsync(x => x.Madde_Ad == addObject.Madde_Ad && !x.isDeleted);
            //if (exist == false)
            //{
                var result = _mapper.Map<Makine_Ekipman_Bilgi_Baslik>(addObject);
                DateTime dateTime = DateTime.Now;
                result.Kullanici_Id = createdByUserId;
                result.Yaratilma_Tarihi = dateTime;
                result.Degistirilme_Tarihi = dateTime;
                await _unitOfWork.makine_Ekipman_Bilgi_BaslikRepository.AddAsync(result);
                await _unitOfWork.SaveAsync();
                var result1 = _mapper.Map<Makine_Ekipman_Bilgi_BaslikDTO>(result);

                return new DataResult<Makine_Ekipman_Bilgi_BaslikDTO>(ResultStatus.Success, result1);
           // }
            //else
            //{
            //    return new DataResult<Makine_Ekipman_Bilgi_BaslikDTO>(ResultStatus.Error, "Veri zaten kayıtlıdır. Lütfen tekrar deneyiniz",
            //null);
            //}
        }

        public async Task<IResult> DeleteAsync(long Id, long deletedByUserId)
        {
            var deleteObject = await _unitOfWork.makine_Ekipman_Bilgi_BaslikRepository.GetAsync(x => x.Id == Id);
            if (deleteObject != null)
            {
                deleteObject.isDeleted = true;
                deleteObject.Degistirilme_Tarihi = DateTime.Now;
                deleteObject.Kullanici_Id = deletedByUserId;
                await _unitOfWork.makine_Ekipman_Bilgi_BaslikRepository.UpdateAsync(deleteObject);
                await _unitOfWork.SaveAsync();
                return new Result(ResultStatus.Success, $"{deleteObject.Madde_Ad} başarılı bir şekilde silinmiştir.");
            }
            return new Result(ResultStatus.Error, $"{deleteObject.Madde_Ad} bulunamadı.");
        }

        public async Task<IDataResult<IList<Makine_Ekipman_Bilgi_BaslikDTO>>> GetAllAsync()
        {
            var resultObject = await _unitOfWork.makine_Ekipman_Bilgi_BaslikRepository.GetAllAsync(x => x.isActive && !x.isDeleted);
            if (resultObject.Count >= 0)
            {
                var result = _mapper.Map<IList<Makine_Ekipman_Bilgi_BaslikDTO>>(resultObject);
                return new DataResult<IList<Makine_Ekipman_Bilgi_BaslikDTO>>(ResultStatus.Success, result);
            }
            return new DataResult<IList<Makine_Ekipman_Bilgi_BaslikDTO>>(ResultStatus.Error, "Aradığınız kriterlere uygun veri bulunamadı",
            null);
        }


        public async Task<IDataResult<Makine_Ekipman_Bilgi_BaslikDTO>> GetAsync(long Id)
        {
            var resultObject = await _unitOfWork.makine_Ekipman_Bilgi_BaslikRepository.GetAsync(x => x.Id == Id);
            if (resultObject != null)
            {
                var result = _mapper.Map<Makine_Ekipman_Bilgi_BaslikDTO>(resultObject);
                return new DataResult<Makine_Ekipman_Bilgi_BaslikDTO>(ResultStatus.Success, result);
            }
            return new DataResult<Makine_Ekipman_Bilgi_BaslikDTO>(ResultStatus.Error, "Aradığınız kriterlere uygun veri bulunamadı",
            null);
        }

        public async Task<IResult> HardDeleteAsync(long Id)
        {
            var deleteObject = await _unitOfWork.makine_Ekipman_Bilgi_BaslikRepository.GetAsync(x => x.Id == Id);
            if (deleteObject != null)
            {

                await _unitOfWork.makine_Ekipman_Bilgi_BaslikRepository.RemoveAsync(deleteObject);
                await _unitOfWork.SaveAsync();
                return new Result(ResultStatus.Success, $"{deleteObject.Madde_Ad} veritabanından başarılı bir şekilde silinmiştir.");
            }
            return new Result(ResultStatus.Error, $"{deleteObject.Madde_Ad} bulunamadı.");
        }

        public async Task<IResult> UpdateAsync(Makine_Ekipman_Bilgi_BaslikDTO updateObject, long modifiedByUserId)
        {
            var exist = await _unitOfWork.makine_Ekipman_Bilgi_BaslikRepository.AnyAsync(x => x.Madde_Ad == updateObject.Madde_Ad && !x.isDeleted
             && x.Id != updateObject.Id);
            if (exist == false)
            {
                var resultObject = await _unitOfWork.makine_Ekipman_Bilgi_BaslikRepository.GetAsync(x => x.Id == updateObject.Id);
                if (resultObject != null)
                {
                    var result = _mapper.Map<Makine_Ekipman_Bilgi_BaslikDTO, Makine_Ekipman_Bilgi_Baslik>(updateObject, resultObject);
                    DateTime dateTime = DateTime.Now;
                    result.Kullanici_Id = modifiedByUserId;
                    result.Degistirilme_Tarihi = dateTime;
                    await _unitOfWork.makine_Ekipman_Bilgi_BaslikRepository.UpdateAsync(result);
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

        public async Task<IDataResult<IList<Makine_Ekipman_Bilgi_BaslikDTO>>> GetAllMakineEkipmanAsync(long Id)
        {
            var resultObject = await _unitOfWork.makine_Ekipman_Bilgi_BaslikRepository.GetAllAsync(x => x.isActive && !x.isDeleted && x.Makine_Ekipman_Id==Id);
            if (resultObject.Count >= 0)
            {
                var result = _mapper.Map<IList<Makine_Ekipman_Bilgi_BaslikDTO>>(resultObject);
                return new DataResult<IList<Makine_Ekipman_Bilgi_BaslikDTO>>(ResultStatus.Success, result);
            }
            return new DataResult<IList<Makine_Ekipman_Bilgi_BaslikDTO>>(ResultStatus.Error, "Aradığınız kriterlere uygun veri bulunamadı",
            null);
        }
    }

}
