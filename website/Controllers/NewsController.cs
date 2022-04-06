using System;//Guid
using System.Collections.Generic;//IEnumerable
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;//ControllerBase
using website.Dtos;
using website.Entities;//New
using website.Repositories;//InMemNewsRepository

namespace website.Controllers
{
    [ApiController]
    [Route("news")]
    public class NewsController : ControllerBase
    {
        private readonly NNewsRepository repositoryNew;
        public NewsController(NNewsRepository repositoryNew2)
        {
            this.repositoryNew = repositoryNew2;
        }

        //Author 
        //GET/news
        [HttpGet]
        public async Task<IEnumerable<NewDto>> GetNewsAsync()
        {
            var news = (await repositoryNew.GetNewsAsync())
                        .Select(new2 => new2.AsDtoNew());
            return news;
        }

        //User -- Author -- Editor -- Admin
        //GET TRUE NEW = Tin tuc da duoc duyet
    
        [HttpGet("true")]
        public async Task<IEnumerable<NewDto>> GetNewsTrueAsync()
        {
            var news = (await repositoryNew.GetNewsTrueAsync())
                        .Select(new2 => new2.AsDtoNewTrue());
            return news;
        }

        //Admin - GET NEW all (true & false)
        //GET/news/{idNew22}
        [HttpGet("{idNew22}")]
        public async Task<ActionResult<NewDto>> GetNewAsync(Guid idNew22)
        {
            var neww = await repositoryNew.GetNewAsync(idNew22);
            if (neww is null)
            {
                return NotFound();
            }
            return neww.AsDtoNew();
        }
        //User - Author - Editor - Admin - GET NEW true 
        //GET/news/true/{idNew22}
        [HttpGet("true/{idNew22}")]
        public async Task<ActionResult<NewDto>> GetNewTrueAsync(Guid idNew22)
        {
            var neww =await repositoryNew.GetNewTrueAsync(idNew22);//GetNewTrue cua NNewRepository
            if (neww is null)
            {
                return NotFound();
            }
            return neww.AsDtoNewTrue();
        }
        //GET/news/true/{idNew22}
        [HttpGet("false/{idNew22}")]
        public async Task<ActionResult<NewDto>> GetNewFalseAsync(Guid idNew22)
        {
            var neww = await repositoryNew.GetNewFalseAsync(idNew22);//GetNewTrue cua NNewRepository
            if (neww is null)
            {
                return NotFound();
            }
            return neww.AsDtoNewFalse();
        }

        //Author , Admin
        //CreateNew co status = false
        //POST/news
        [HttpPost]
        public async Task<ActionResult<NewDto>> CreateNewAsync(CreateNewDto newDto)
        {
            New new2 = new()
            {
                _id = Guid.NewGuid(),
                title = newDto.title,
                description = newDto.description,
                content = newDto.content,
                // status = newDto.status,  -- Editor đổi lại status = true thì new được đăng
                status = false,  //Để status luôn false
                idImage = newDto.idImage,
                idTop = newDto.idTop,
                idAc = newDto.idAc,
                creatDate = DateTimeOffset.UtcNow
            };
            await repositoryNew.CreateNewAsync(new2);
            return CreatedAtAction(nameof(GetNewAsync), new { idNew22 = new2._id }, new2.AsDtoNew());
            //Chu y : idNew22 = new2.idNew -- idNew22 la cua GetNew , khong duoc thay doi, se loi No route 
        }

        //Author , Admin
        //UPDATE NEW  -- status = true ---- Xai them GetNewTrue tren no se hien thi tin da duyet
        //PUT/news/{idNew22}
        [HttpPut("{idNew22}")] //CHÚ Ý phải có ngoặc -- nó mới hiểu đường dẫn https://localhost:5001/news/idNew2
        //Author/Editor/Admin
        public async Task<ActionResult> UpdateNewAsync(Guid idNew22, UpdateNewDto newDto)
        {
            //Đặt biến New_tồn_tại
            var existingNew = await repositoryNew.GetNewAsync(idNew22);
            if (existingNew is null)
            {
                return NotFound();
            }
            New updateNew = existingNew with
            {
                title = newDto.title,
                description = newDto.description,
                content = newDto.content,
                idImage = newDto.idImage,
                idTop = newDto.idTop,
                idAc = newDto.idAc,
                creatDate = DateTimeOffset.UtcNow
            };
            await repositoryNew.UpdateNewAsync(updateNew);
            return NoContent();
        }
        //OkUpdateNew - Editor/Admin
        //PUT/news/{idNew22}
        //Hàm OkeUpdateNew và OkeyUpdateNew ko giống nhau
        [HttpPut("editor/{idNew22}")]
        public async Task<ActionResult> OkeUpdateNewActionResult(Guid idNew22, OkeyUpdateNewDto newDto)
        {
            //Đặt biến New_tồn_tại
            var existingNew = await repositoryNew.GetNewAsync(idNew22);
            if (existingNew is null)
            {
                return NotFound();
            }
            New updateNew = existingNew with
            {
                status = true,                            //Cap nhat lai status = true
                creatDate = DateTimeOffset.UtcNow        //Cap nhat lai ngay tao tin        
            };
            await repositoryNew.OkeyUpdateNewAsync(updateNew);
            return NoContent();
        }

        //DELETE/news/{idNew22}
        [HttpDelete("{idNew22}")]
        public async Task<ActionResult> DeleteNewAsync(Guid idNew22)
        {
            var existigNew = await repositoryNew.GetNewAsync(idNew22);
            if(existigNew is null)
            {
                return NotFound();
            }
            await repositoryNew.DeleteNewAsync(idNew22);
            return NoContent();

        }

        //DELETE/news/false/{idNew22}
        [HttpDelete("false/{idNew22}")]
        public async Task<ActionResult> DeleteNewFalseAsync(Guid idNew22)
        {
            var existigNew = await repositoryNew.GetNewFalseAsync(idNew22);
            if(existigNew is null)
            {
                return NotFound();
            }
            await repositoryNew.DeleteNewAsync(idNew22);
            return NoContent();

        }
        

    }
}