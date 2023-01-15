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
    public class Makine_EkipmanManager : IMakine_EkipmanService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public Makine_EkipmanManager(IUnitOfWork unitOfWork,IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task<IResult> AddAsync(Makine_EkipmanDTO addObject, long createdByUserId)
        {
            var exist =await _unitOfWork.makine_EkipmanRepository.AnyAsync(x => x.Ekipman_Kodu == addObject.Ekipman_Kodu);
            if (exist == false)
            {
                var result = _mapper.Map<Makine_Ekipman>(addObject);
                DateTime dateTime = DateTime.Now;
                result.Kullanici_Id = createdByUserId;
                result.Yaratilma_Tarihi = dateTime;
                result.Degistirilme_Tarihi = dateTime;
                await _unitOfWork.makine_EkipmanRepository.AddAsync(result);
                await _unitOfWork.SaveAsync();
                return new Result(ResultStatus.Success, $"{result.Ekipman_Kodu} kodlu ekipman başarılı bir şekilde eklenmiştir.");
            }
            else
            {
                return new Result(ResultStatus.Error, $"{addObject.Ekipman_Kodu} kodlu ekipman zaten kayıtlıdır. Lütfen kontrol edip tekrar deneyiniz.");
            }
        }

        public async Task<IDataResult<Makine_EkipmanDTO>> AddAndGetAsync(Makine_EkipmanDTO addObject, long createdByUserId)
        {
            var exist = await _unitOfWork.makine_EkipmanRepository.AnyAsync(x => x.Ekipman_Kodu == addObject.Ekipman_Kodu && !x.isDeleted);
            if (exist == false)
            {
                var result = _mapper.Map<Makine_Ekipman>(addObject);
                DateTime dateTime = DateTime.Now;
                result.Kullanici_Id = createdByUserId;
                result.Yaratilma_Tarihi = dateTime;
                result.Degistirilme_Tarihi = dateTime;
                await _unitOfWork.makine_EkipmanRepository.AddAsync(result);
                await _unitOfWork.SaveAsync();
                var result1 = _mapper.Map<Makine_EkipmanDTO>(result);

                return new DataResult<Makine_EkipmanDTO>(ResultStatus.Success, result1);
            }
            else
            {
                return new DataResult<Makine_EkipmanDTO>(ResultStatus.Error, "Veri zaten kayıtlıdır. Lütfen tekrar deneyiniz",
            null);
            }
        }



        public async Task<IResult> DeleteAsync(long Id, long deletedByUserId)
        {
            var deleteObject = await _unitOfWork.makine_EkipmanRepository.GetAsync(x => x.Id == Id);
            if (deleteObject != null)
            {
                deleteObject.isDeleted = true;
                deleteObject.Degistirilme_Tarihi = DateTime.Now;
                deleteObject.Kullanici_Id = deletedByUserId;
                await _unitOfWork.makine_EkipmanRepository.UpdateAsync(deleteObject);
                await _unitOfWork.SaveAsync();
                return new Result(ResultStatus.Success, $"{deleteObject.Ekipman_Kodu} kodlu ekipman  başarılı bir şekilde silinmiştir.");
            }
            return new Result(ResultStatus.Error, $"{deleteObject.Ekipman_Kodu} kodlu ekipman  bulunamadı.");
        }

        public async Task<IDataResult<IList<Makine_EkipmanDTO>>> GetAllAsync(long Id)
        {
            var resultObject = await _unitOfWork.makine_EkipmanRepository.GetAllAsync(x => x.isActive && !x.isDeleted && x.Birim_Id==Id);
            if (resultObject.Count >= 0)
            {
                var result = _mapper.Map<IList<Makine_EkipmanDTO>>(resultObject);
                return new DataResult<IList<Makine_EkipmanDTO>>(ResultStatus.Success, result);
            }
            return new DataResult<IList<Makine_EkipmanDTO>>(ResultStatus.Error, "Aradığınız kriterlere uygun veri bulunamadı",
            null);
        }

        public async Task<IDataResult<Makine_EkipmanDTO>> GetAsync(long Id)
        {
            var resultObject = await _unitOfWork.makine_EkipmanRepository.GetAsync(x => x.Id == Id);
            if (resultObject != null)
            {
                var result = _mapper.Map<Makine_EkipmanDTO>(resultObject);
                return new DataResult<Makine_EkipmanDTO>(ResultStatus.Success, result);
            }
            return new DataResult<Makine_EkipmanDTO>(ResultStatus.Error, "Aradığınız kriterlere uygun veri bulunamadı",
            null);
        }

        public async Task<IResult> HardDeleteAsync(long Id)
        {
            var deleteObject = await _unitOfWork.makine_EkipmanRepository.GetAsync(x => x.Id == Id);
            if (deleteObject != null)
            {

                await _unitOfWork.makine_EkipmanRepository.RemoveAsync(deleteObject);
                await _unitOfWork.SaveAsync();
                return new Result(ResultStatus.Success, $"{deleteObject.Ekipman_Kodu} kodlu ekipman veritabanından başarılı bir şekilde silinmiştir.");
            }
            return new Result(ResultStatus.Error, $"{deleteObject.Ekipman_Kodu} kodlu ekipman  bulunamadı.");
        }

        public async Task<IResult> UpdateAsync(Makine_EkipmanDTO updateObject, long modifiedByUserId)
        {
            var exist = await _unitOfWork.makine_EkipmanRepository.AnyAsync(x => x.Ekipman_Kodu == updateObject.Ekipman_Kodu && x.Id != updateObject.Id);
            if (exist == false)
            {
                var resultObject = await _unitOfWork.makine_EkipmanRepository.GetAsync(x => x.Id == updateObject.Id);
                if (resultObject != null)
                {
                    var result = _mapper.Map<Makine_EkipmanDTO,Makine_Ekipman>(updateObject,resultObject);
                    DateTime dateTime = DateTime.Now;
                    result.Kullanici_Id = modifiedByUserId;
                    result.Degistirilme_Tarihi = dateTime;
                    await _unitOfWork.makine_EkipmanRepository.UpdateAsync(result);
                    await _unitOfWork.SaveAsync();
                    return new Result(ResultStatus.Success, $"{result.Ekipman_Kodu} kodlu ekipman başarılı bir şekilde Güncellenmiştir.");
                }
                else
                {
                    return new Result(ResultStatus.Error, $"{updateObject.Ekipman_Kodu} kodlu ekipman bulunamadı.");
                }
            }
            else
            {
                return new Result(ResultStatus.Error, $"{updateObject.Ekipman_Kodu} kodlu ekipman zaten kayıtlıdır. Lütfen kontrol edip tekrar deneyiniz.");
            }
        }


        public async Task<IDataResult<Makine_EkipmanDTO>> ReadQRCOdeAsync(string QRCode)
        {
            var resultObject = await _unitOfWork.makine_EkipmanRepository.GetAsync(x => x.QRCode == QRCode);
            if (resultObject != null)
            {
                var result = _mapper.Map<Makine_EkipmanDTO>(resultObject);
                return new DataResult<Makine_EkipmanDTO>(ResultStatus.Success, result);
            }
            return new DataResult<Makine_EkipmanDTO>(ResultStatus.Error, "Aradığınız kriterlere uygun veri bulunamadı",
            null);
        }

        public async Task<IDataResult<Makine_EkipmanDTO>> ReadEkipmanKodAsync(string EkipmanKod)
        {
            var resultObject = await _unitOfWork.makine_EkipmanRepository.GetAsync(x => x.Ekipman_Kodu == EkipmanKod);
            if (resultObject != null)
            {
                var result = _mapper.Map<Makine_EkipmanDTO>(resultObject);
                return new DataResult<Makine_EkipmanDTO>(ResultStatus.Success, result);
            }
            return new DataResult<Makine_EkipmanDTO>(ResultStatus.Error, "Aradığınız kriterlere uygun veri bulunamadı",
            null);
        }




    }
}
