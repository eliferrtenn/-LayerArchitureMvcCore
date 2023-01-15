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
    public class Egitim_Veren_PersonelManager : IEgitim_Veren_PersonelService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public Egitim_Veren_PersonelManager(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task<IResult> AddAsync(Egitim_Veren_PersonelDTO addObject, long createdByUserId)
        {

            var result = _mapper.Map<Egitim_Veren_Personel>(addObject);
            DateTime dateTime = DateTime.Now;
            result.Kullanici_Id = createdByUserId;
            result.Yaratilma_Tarihi = dateTime;
            result.Degistirilme_Tarihi = dateTime;
            await _unitOfWork.egitim_Veren_PersonelRepository.AddAsync(result);
            await _unitOfWork.SaveAsync();
            return new Result(ResultStatus.Success, $"Personel başraılı bir şekilde başarılı bir şekilde atanmıştır.");
        }

        public async Task<IResult> DeleteAsync(long Id, long deletedByUserId)
        {
            var deleteObject = await _unitOfWork.egitim_Veren_PersonelRepository.GetAsync(x => x.Id == Id);
            if (deleteObject != null)
            {
                deleteObject.isDeleted = true;
                deleteObject.Degistirilme_Tarihi = DateTime.Now;
                deleteObject.Kullanici_Id = deletedByUserId;
                await _unitOfWork.egitim_Veren_PersonelRepository.UpdateAsync(deleteObject);
                await _unitOfWork.SaveAsync();
                return new Result(ResultStatus.Success, $"Çıkarmak istediğiniz kişinin eğitimi başarılı bir şekilde silinmiştir.");
            }
            return new Result(ResultStatus.Error, $"Çıkarmak istediğiniz kişisinin  eğitimi bulunamadı.");
        }

        public async Task<IDataResult<IList<Egitim_Veren_PersonelDTO>>> GetAllAsync()
        {
            var resultObject = await _unitOfWork.egitim_Veren_PersonelRepository.GetAllAsync(x => x.isActive && !x.isDeleted);
            if (resultObject.Count >= 0)
            {
                var result = _mapper.Map<IList<Egitim_Veren_PersonelDTO>>(resultObject);
                return new DataResult<IList<Egitim_Veren_PersonelDTO>>(ResultStatus.Success, result);
            }
            return new DataResult<IList<Egitim_Veren_PersonelDTO>>(ResultStatus.Error, "Aradığınız kriterlere uygun veri bulunamadı",
            null);
        }
        public async Task<IDataResult<IList<Egitim_Veren_PersonelDTO>>> GetAllEgitimVeren(long Id)
        {
            var resultObject = await _unitOfWork.egitim_Veren_PersonelRepository.GetAllAsync(x => x.isActive && !x.isDeleted && x.Egitim_Tanimla_Id==Id);
            if (resultObject.Count >= 0)
            {
                var result = _mapper.Map<IList<Egitim_Veren_PersonelDTO>>(resultObject);
                return new DataResult<IList<Egitim_Veren_PersonelDTO>>(ResultStatus.Success, result);
            }
            return new DataResult<IList<Egitim_Veren_PersonelDTO>>(ResultStatus.Error, "Aradığınız kriterlere uygun veri bulunamadı",
            null);
        }

        public async Task<IDataResult<Egitim_Veren_PersonelDTO>> GetAsync(long Id)
        {
            var resultObject = await _unitOfWork.egitim_Veren_PersonelRepository.GetAsync(x => x.Id == Id);
            if (resultObject != null)
            {
                var result = _mapper.Map<Egitim_Veren_PersonelDTO>(resultObject);
                return new DataResult<Egitim_Veren_PersonelDTO>(ResultStatus.Success, result);
            }
            return new DataResult<Egitim_Veren_PersonelDTO>(ResultStatus.Error, "Aradığınız kriterlere uygun veri bulunamadı",
            null);
        }

        public async Task<IResult> HardDeleteAsync(long Id)
        {
            var deleteObject = await _unitOfWork.egitim_Veren_PersonelRepository.GetAsync(x => x.Id == Id);
            if (deleteObject != null)
            {

                await _unitOfWork.egitim_Veren_PersonelRepository.RemoveAsync(deleteObject);
                await _unitOfWork.SaveAsync();
                return new Result(ResultStatus.Success, $"Çıkarmak istedğiniz personel eğitimden başarılı bir şekilde çıkarılmıştır.");
            }
            return new Result(ResultStatus.Error, $"Çıkarmak istediğinz personel eğitimde bulunamadı.");
        }

        public async Task<IResult> UpdateAsync(Egitim_Veren_PersonelDTO updateObject, long modifiedByUserId)
        {
            var exist = await _unitOfWork.egitim_Veren_PersonelRepository.AnyAsync(x => x.Personel_Id == updateObject.Personel_Id
             && x.Egitim_Tanimla_Id == updateObject.Egitim_Tanimla_Id && x.Id != updateObject.Id);
            if (exist == false)
            {
                var resultObject = await _unitOfWork.egitim_Veren_PersonelRepository.GetAsync(x => x.Id == updateObject.Id);
                if (resultObject != null)
                {
                    var result = _mapper.Map<Egitim_Veren_PersonelDTO, Egitim_Veren_Personel>(updateObject, resultObject);
                    DateTime dateTime = DateTime.Now;
                    result.Kullanici_Id = modifiedByUserId;
                    result.Degistirilme_Tarihi = dateTime;
                    await _unitOfWork.egitim_Veren_PersonelRepository.UpdateAsync(result);
                    await _unitOfWork.SaveAsync();
                    return new Result(ResultStatus.Success, $"{result.Personel_Bilgi.Ad_Soyad} kişisi başarılı bir şekilde Güncellenmiştir.");
                }
                else
                {
                    return new Result(ResultStatus.Error, $"{updateObject.Personel_Id} kişisi bulunamadı.");
                }
            }
            else
            {
                return new Result(ResultStatus.Error, $"{updateObject.Personel_Id} kişisinin eğitimi zaten kayıtlıdır. Lütfen kontrol edip tekrar deneyiniz.");
            }
        }
    }
}
