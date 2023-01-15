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
    public class KullaniciManager : IKullaniciService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public KullaniciManager(IUnitOfWork unitOfWork,IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task<IResult> AddAsync(KullaniciDTO addObject, long createdByUserId)
        {
            var exist =await  _unitOfWork.kullanici_Repository.AnyAsync(x => x.Password == addObject.Password);
            if (exist == false)
            {
                var result = _mapper.Map<Kullanici>(addObject);
                DateTime dateTime = DateTime.Now;
                result.Kullanici_Id = createdByUserId;
                result.Yaratilma_Tarihi = dateTime;
                result.Degistirilme_Tarihi = dateTime;
                await _unitOfWork.kullanici_Repository.AddAsync(result);
                await _unitOfWork.SaveAsync();
                return new Result(ResultStatus.Success, "Yetki alanı başarılı bir şekilde eklenmiştir.");
            }
            else
            {
                return new Result(ResultStatus.Error, "Yetki alanı zaten kayıtlıdır. Lütfen kontrol edip tekrar deneyiniz.");
            }
        }

        public async Task<IResult> DeleteAsync(long Id, long deletedByUserId)
        {
            var deleteObject = await _unitOfWork.kullanici_Repository.GetAsync(x => x.Id == Id);
            if (deleteObject != null)
            {
                deleteObject.isDeleted = true;
                deleteObject.Degistirilme_Tarihi = DateTime.Now;
                deleteObject.Kullanici_Id = deletedByUserId;
                await _unitOfWork.kullanici_Repository.UpdateAsync(deleteObject);
                await _unitOfWork.SaveAsync();
                return new Result(ResultStatus.Success, "Yetki alanı başarılı bir şekilde silinmiştir.");
            }
            return new Result(ResultStatus.Error, "Yetki alanı bulunamadı.");
        }

        public async Task<IDataResult<IList<KullaniciDTO>>> GetAllAsync()
        {
            var resultObject = await _unitOfWork.kullanici_Repository.GetAllAsync(x => x.isActive && !x.isDeleted);
            if (resultObject.Count >= 0)
            {
                var result = _mapper.Map<IList<KullaniciDTO>>(resultObject);
                return new DataResult<IList<KullaniciDTO>>(ResultStatus.Success, result);
            }
            return new DataResult<IList<KullaniciDTO>>(ResultStatus.Error, "Aradığınız kriterlere uygun veri bulunamadı",
            null);
        }

        public async Task<IDataResult<KullaniciDTO>> GetAsync(long Id)
        {
            var resultObject = await _unitOfWork.kullanici_Repository.GetAsync(x => x.Id == Id);
            if (resultObject != null)
            {
                var result = _mapper.Map<KullaniciDTO>(resultObject);
                return new DataResult<KullaniciDTO>(ResultStatus.Success, result);
            }
            return new DataResult<KullaniciDTO>(ResultStatus.Error, "Aradığınız kriterlere uygun veri bulunamadı",
            null);
        }
                     
        public async Task<IDataResult<KullaniciDTO>> GetKullanci(string mail, string sifre)
        {
            var resultObject = await _unitOfWork.kullanici_Repository.GetAsync(x=>x.Password == sifre && x.Mail==mail);

            if (resultObject != null)
            {
                var result = _mapper.Map<KullaniciDTO>(resultObject);
                return new DataResult<KullaniciDTO>(ResultStatus.Success, result);
            }

            return new DataResult<KullaniciDTO>(ResultStatus.Error, "Aradığınız kriterlere uygun veri bulunamadı",
            null);

        }

        public async Task<IResult> HardDeleteAsync(long Id)
        {
            var deleteObject = await _unitOfWork.kullanici_Repository.GetAsync(x => x.Id == Id);
            if (deleteObject != null)
            {

                await _unitOfWork.kullanici_Repository.RemoveAsync(deleteObject);
                await _unitOfWork.SaveAsync();
                return new Result(ResultStatus.Success, $"{deleteObject.Password} kişisi veritabanından başarılı bir şekilde silinmiştir.");
            }
            return new Result(ResultStatus.Error, $"{deleteObject.Password} kişisi bulunamadı.");
        }

        public async Task<IResult> UpdateAsync(KullaniciDTO updateObject, long modifiedByUserId)
        {
            var exist =await  _unitOfWork.kullanici_Repository.AnyAsync(x => x.Password == updateObject.Password && x.Id != updateObject.Id);
            if (exist == false)
            {
                var resultObject = await _unitOfWork.kullanici_Repository.GetAsync(x => x.Id == updateObject.Id);
            if (resultObject != null)
            {
                var result = _mapper.Map<KullaniciDTO,Kullanici>(updateObject,resultObject);
                DateTime dateTime = DateTime.Now;
                result.Kullanici_Id = modifiedByUserId;
                result.Degistirilme_Tarihi = dateTime;
                await _unitOfWork.kullanici_Repository.UpdateAsync(result);
                await _unitOfWork.SaveAsync();
                return new Result(ResultStatus.Success, "Yetki alanı başarılı bir şekilde Güncellenmiştir.");
            }
            else
            {
                return new Result(ResultStatus.Error, "Yetki alanı bulunamadı.");
            }
            }
            else
            {
                return new Result(ResultStatus.Error,"Yetki alanı zaten kayıtlıdır. Lütfen kontrol edip tekrar deneyiniz.");
            }
        }


        public async Task<IDataResult<KullaniciDTO>> GetYetkiliAsync(long Id)
        {
            var resultObject = await _unitOfWork.kullanici_Repository.GetAsync(x => x.Id == Id);
            if (resultObject != null)
            {
                var result = _mapper.Map<KullaniciDTO>(resultObject);
                return new DataResult<KullaniciDTO>(ResultStatus.Success, result);
            }
            return new DataResult<KullaniciDTO>(ResultStatus.Error, "Aradığınız kriterlere uygun veri bulunamadı",
            null);
        }
    }
}
