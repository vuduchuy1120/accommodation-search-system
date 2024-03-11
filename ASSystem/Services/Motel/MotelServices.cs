using ASSystem.Dtos;
using ASSystem.Exceptions;
using ASSystem.Models;
using ASSystem.Repository.Motel;
using AutoMapper;
using System.Net;

namespace ASSystem.Services.Motel
{
    public class MotelServices : IMotelServices
    {
        private readonly MotelRepository _motelRepository;
        private readonly IMapper _mapper;
        public MotelServices(IMapper mapper, MotelRepository motelRepository)
        {
            _mapper = mapper;
            _motelRepository = motelRepository;
        }
        public async Task<ApiResponse<MotelDto>> CreateMotel(MotelDto motelDto)
        {
            try
            {
                var motel = _mapper.Map<ASSystem.Models.Motel>(motelDto);
                var result = await _motelRepository.CreateMotel(motel);

                if (!result)
                {
                    throw new MyException((int)HttpStatusCode.BadRequest, "Create motel failed.");
                }

                return new ApiResponse<MotelDto>
                {
                    Success = true,
                    Message = "Create motel successfully.",
                    Data = _mapper.Map<MotelDto>(motel)
                };
            }
            catch (Exception ex)
            {
                // Log the exception for debugging or monitoring purposes
                // logger.LogError(ex, "Error occurred while creating motel.");

                return new ApiResponse<MotelDto>
                {
                    Success = false,
                    Message = $"Failed to create motel: {ex.Message}",
                    Data = null
                };
            }
        }

        public Task<ApiResponse<MotelDto>> DeleteMotel(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<ApiResponse<List<MotelwithImagesDto>>> GetAllMotel()
        {
            var motels = await _motelRepository.GetAllMotel();
            return new ApiResponse<List<MotelwithImagesDto>>
            {
                Success = true,
                Message = "Get all motels successfully.",
                Data = _mapper.Map<List<MotelwithImagesDto>>(motels)
            };
        }

        public Task<ApiResponse<List<MotelDto>>> GetMotelByAccountId(int accountId)
        {
            throw new NotImplementedException();
        }

        public async Task<ApiResponse<MotelwithImagesDto>> GetMotelById(int id)
        {
            var motel1 = await _motelRepository.GetMotelByIdWithImages(id);

            if (motel1 == null)
            {
                return new ApiResponse<MotelwithImagesDto>
                {
                    Success = false,
                    Message = "Motel not found.",
                    Data = null
                };
            }
            MotelwithImagesDto motelMap = new MotelwithImagesDto
            {
                MotelId = motel1.MotelId,
                AccountId = motel1.AccountId,
                Tittle = motel1.Tittle,
                Description = motel1.Description,
                Address = motel1.Address,
                Price = motel1.Price,
                QuantityEmptyRooms = motel1.QuantityEmptyRooms,
                Contact = motel1.Contact,
                Province = motel1.Province,
                District = motel1.District,
                Ward = motel1.Ward,
                Status = motel1.Status,
                DeleteAt = motel1.DeleteAt,

                RoomImages = motel1.RoomImages.Select(x => new RoomImageDto
                {
                    RoomImageId = x.RoomImageId,
                    MotelId = x.MotelId,
                    PathImageDetail = x.PathImageDetail
                }).ToList()
            };
            return new ApiResponse<MotelwithImagesDto>
            {
                Success = true,
                Message = "Get all motels successfully.",
                Data = _mapper.Map<MotelwithImagesDto>(motel1)
            };

        }

        public Task<ApiResponse<MotelDto>> UpdateMotel(MotelDto motel)
        {
            throw new NotImplementedException();
        }

        public async Task<ApiResponse<MotelwithImagesDto>> UploadImage(int id, IFormFile[] images)
        {

            // Tìm kiếm motel
            var motel = _motelRepository.GetMotelById(id);
            if (motel == null)
            {
                return new ApiResponse<MotelwithImagesDto>
                {
                    Success = false,
                    Message = "Không tìm thấy khách sạn.",
                    Data = null
                };
            }

            // Kiểm tra xem có hình ảnh được tải lên không
            if (images.Length > 0)
            {
                foreach (var image in images)
                {
                    // Lưu hình ảnh vào thư mục wwwroot/images
                    var fileName = Guid.NewGuid().ToString() + Path.GetExtension(image.FileName);
                    var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "images", fileName);
                    using (var stream = new FileStream(path, FileMode.Create))
                    {
                        await image.CopyToAsync(stream);
                    }

                    // Thêm đường dẫn hình ảnh vào cơ sở dữ liệu
                    RoomImage roomImage = new RoomImage
                    {
                        MotelId = id,
                        PathImageDetail = "/images/" + fileName
                    };
                    await _motelRepository.CreateRoomImage(roomImage);
                }

                // Lấy lại thông tin motel sau khi thêm hình ảnh
                ASSystem.Models.Motel motel1 = await _motelRepository.GetMotelById(id);
                MotelwithImagesDto motelMap = new MotelwithImagesDto
                {
                    MotelId = motel1.MotelId,
                    AccountId = motel1.AccountId,
                    Tittle = motel1.Tittle,
                    Description = motel1.Description,
                    Address = motel1.Address,
                    Price = motel1.Price,
                    QuantityEmptyRooms = motel1.QuantityEmptyRooms,
                    Contact = motel1.Contact,
                    Province = motel1.Province,
                    District = motel1.District,
                    Ward = motel1.Ward,
                    Status = motel1.Status,
                    DeleteAt = motel1.DeleteAt,

                    RoomImages = motel1.RoomImages.Select(x => new RoomImageDto
                    {
                        RoomImageId = x.RoomImageId,
                        MotelId = x.MotelId,
                        PathImageDetail = x.PathImageDetail
                    }).ToList()
                };
                return new ApiResponse<MotelwithImagesDto>
                {
                    Success = true,
                    Message = "Tải hình ảnh lên thành công.",
                    Data = motelMap
                };
            }
            else
            {
                return new ApiResponse<MotelwithImagesDto>
                {
                    Success = false,
                    Message = "Không có hình ảnh được tải lên.",
                    Data = null
                };
            }
        }
    }
}
