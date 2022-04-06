using System;//Guid
using System.Collections.Generic;//List
using System.Linq;
using System.Threading.Tasks;
using website.Entities;//New

namespace website.Repositories
{


    public class InMemNewsRepository : NNewsRepository
    {
        private readonly List<New> news = new()
        {
            new New
            {
                _id = Guid.NewGuid(),
                title = "Tin tức số 1",
                description = "Mô tả của tin tức số 1",
                content = "Tình yêu thương có nghĩa là gì? Đó là thứ tình cảm thiêng liêng, quý báu là sự quan tâm giữa con người và con người với nhau. Vậy tại sao chúng ta cần phải có tình yêu thương? Bởi vì nó thể hiện phẩm chất cao quý của một con người. Có tình yêu thương, con người bỗng trở nên tốt đẹp hơn trong tâm hồn. Nó nuôi dưỡng tâm hồn chúng ta ngày càng hoàn thiện hơn về mặt nhân cách, nhân phẩm, đạo đức. Nhờ có tình yêu thương mà những nỗi đau, vết thương trong tâm hồn dường như được hàn gắn, khiến cho xã hội ngày một tốt đẹp hơn, phát triển tốt hơn. Dẫn chứng mà chúng ta dễ dàng thấy được đó chính là những phong trào kêu gọi sự giúp đỡ đồng bào miền Trung bị lũ lụt hàng năm hoành hành, vùng đồng bằng Sông Cửu Long bị thiên tai tàn phá nặng nề. Khi đất nước Nhật Bản bị sóng thần ập vào tàn phá đã để lại biết bao hậu quả đau thương về người, về của cho đất nước này. Tình yêu thương đã được nhân rộng khắp thế giới khi mà phong trào ủng hộ giúp đỡ nhân dân Nhật Bản khắc phục phần nào nỗi đau thương, mất mát này được nở rộ và mạnh mẽ. Những sự việc nêu trên thể hiện tình yêu thương con người luôn luôn sẵn có trong trái tim của mỗi con người nhưng khi có dịp thì tấm lòng yêu thương ấy bỗng trỗi dậy mạnh mẽ như đợt sóng trào dâng. Ngoài những hoạt động, phong trào lớn đó thì ở ngay tại trường lớp tôi cũng có những bạn có gia đình rất nghèo khó cần được giúp đỡ, vì gia đình quá khốn khó mà nhiều bạn phải nghỉ học để phụ giúp gia đình mưu sinh. Chúng tôi là học sinh, tuy không có nhiều tiền nhưng mỗi người một chút, mỗi ngày góp chút ít thì sau một khoảng thời gian chúng tôi vẫn có thể giúp đỡ những bạn nghèo khó này đi học dưới sự giúp đỡ của quý thầy cô trong nhà trường. Những biểu hiện đó phần nào nói lên tình yêu thương luôn có mặt ở khắp mọi nơi."
            ,
                status = false,
                idImage = "anh1",
                idTop = "top1",
                idAc = "ac1",
                creatDate = DateTimeOffset.UtcNow
            },

            new New
            {
                _id = Guid.NewGuid(),
                title = "Tin tức số 2",
                description = "Mô tả của tin tức số 2",
                content = "Tình yêu thương có nghĩa là gì? Đó là thứ tình cảm thiêng liêng, quý báu là sự quan tâm giữa con người và con người với nhau. Vậy tại sao chúng ta cần phải có tình yêu thương? Bởi vì nó thể hiện phẩm chất cao quý của một con người. Có tình yêu thương, con người bỗng trở nên tốt đẹp hơn trong tâm hồn. Nó nuôi dưỡng tâm hồn chúng ta ngày càng hoàn thiện hơn về mặt nhân cách, nhân phẩm, đạo đức. Nhờ có tình yêu thương mà những nỗi đau, vết thương trong tâm hồn dường như được hàn gắn, khiến cho xã hội ngày một tốt đẹp hơn, phát triển tốt hơn. Dẫn chứng mà chúng ta dễ dàng thấy được đó chính là những phong trào kêu gọi sự giúp đỡ đồng bào miền Trung bị lũ lụt hàng năm hoành hành, vùng đồng bằng Sông Cửu Long bị thiên tai tàn phá nặng nề. Khi đất nước Nhật Bản bị sóng thần ập vào tàn phá đã để lại biết bao hậu quả đau thương về người, về của cho đất nước này. Tình yêu thương đã được nhân rộng khắp thế giới khi mà phong trào ủng hộ giúp đỡ nhân dân Nhật Bản khắc phục phần nào nỗi đau thương, mất mát này được nở rộ và mạnh mẽ. Những sự việc nêu trên thể hiện tình yêu thương con người luôn luôn sẵn có trong trái tim của mỗi con người nhưng khi có dịp thì tấm lòng yêu thương ấy bỗng trỗi dậy mạnh mẽ như đợt sóng trào dâng. Ngoài những hoạt động, phong trào lớn đó thì ở ngay tại trường lớp tôi cũng có những bạn có gia đình rất nghèo khó cần được giúp đỡ, vì gia đình quá khốn khó mà nhiều bạn phải nghỉ học để phụ giúp gia đình mưu sinh. Chúng tôi là học sinh, tuy không có nhiều tiền nhưng mỗi người một chút, mỗi ngày góp chút ít thì sau một khoảng thời gian chúng tôi vẫn có thể giúp đỡ những bạn nghèo khó này đi học dưới sự giúp đỡ của quý thầy cô trong nhà trường. Những biểu hiện đó phần nào nói lên tình yêu thương luôn có mặt ở khắp mọi nơi."
            ,
                status = false,
                idImage = "anh2",
                idTop = "top2",
                idAc = "ac2",
                creatDate = DateTimeOffset.UtcNow
            },

            new New
            {
                _id = Guid.NewGuid(),
                title = "Tin tức số 3",
                description = "Mô tả của tin tức số 3",
                content = "Tình yêu thương có nghĩa là gì? Đó là thứ tình cảm thiêng liêng, quý báu là sự quan tâm giữa con người và con người với nhau. Vậy tại sao chúng ta cần phải có tình yêu thương? Bởi vì nó thể hiện phẩm chất cao quý của một con người. Có tình yêu thương, con người bỗng trở nên tốt đẹp hơn trong tâm hồn. Nó nuôi dưỡng tâm hồn chúng ta ngày càng hoàn thiện hơn về mặt nhân cách, nhân phẩm, đạo đức. Nhờ có tình yêu thương mà những nỗi đau, vết thương trong tâm hồn dường như được hàn gắn, khiến cho xã hội ngày một tốt đẹp hơn, phát triển tốt hơn. Dẫn chứng mà chúng ta dễ dàng thấy được đó chính là những phong trào kêu gọi sự giúp đỡ đồng bào miền Trung bị lũ lụt hàng năm hoành hành, vùng đồng bằng Sông Cửu Long bị thiên tai tàn phá nặng nề. Khi đất nước Nhật Bản bị sóng thần ập vào tàn phá đã để lại biết bao hậu quả đau thương về người, về của cho đất nước này. Tình yêu thương đã được nhân rộng khắp thế giới khi mà phong trào ủng hộ giúp đỡ nhân dân Nhật Bản khắc phục phần nào nỗi đau thương, mất mát này được nở rộ và mạnh mẽ. Những sự việc nêu trên thể hiện tình yêu thương con người luôn luôn sẵn có trong trái tim của mỗi con người nhưng khi có dịp thì tấm lòng yêu thương ấy bỗng trỗi dậy mạnh mẽ như đợt sóng trào dâng. Ngoài những hoạt động, phong trào lớn đó thì ở ngay tại trường lớp tôi cũng có những bạn có gia đình rất nghèo khó cần được giúp đỡ, vì gia đình quá khốn khó mà nhiều bạn phải nghỉ học để phụ giúp gia đình mưu sinh. Chúng tôi là học sinh, tuy không có nhiều tiền nhưng mỗi người một chút, mỗi ngày góp chút ít thì sau một khoảng thời gian chúng tôi vẫn có thể giúp đỡ những bạn nghèo khó này đi học dưới sự giúp đỡ của quý thầy cô trong nhà trường. Những biểu hiện đó phần nào nói lên tình yêu thương luôn có mặt ở khắp mọi nơi."
            ,
                status = false,
                idImage = "anh2",
                idTop = "top3",
                idAc = "ac3",
                creatDate = DateTimeOffset.UtcNow
            },

        };

        public List<New> News => news;

        public async Task<IEnumerable<New>> GetNewsAsync()
        {
            return await Task.FromResult(News);
        }
        public async Task<IEnumerable<New>> GetNewsTrueAsync() //2.  Lien ket voi NewsController
        {
            var neww = news.Where(neww2=> neww2.status == true);
            return await Task.FromResult(neww);
        }

        public async Task<New> GetNewAsync(Guid iDNew)
        {
            var neww = news.Where(new2 => new2._id == iDNew).SingleOrDefault();
            return await Task.FromResult(neww);
        }
        public async Task<New> GetNewTrueAsync(Guid idNeww)
        {
            var neww = news.Where(new2 => new2._id == idNeww && new2.status == true).SingleOrDefault();
            return await Task.FromResult(neww);
            //Tra ve newtrue co idNew = idNeww va status = true
        }
        public async Task<New> GetNewFalseAsync(Guid idNeww)
        {
            var neww = news.Where(new2 => new2._id == idNeww && new2.status == false).SingleOrDefault();
            return await Task.FromResult(neww);
        }
        public async Task CreateNewAsync(New new2)
        {
            news.Add(new2);
            await Task.CompletedTask;
        }

        public async Task UpdateNewAsync(New new2)
        {
            var index = news.FindIndex(existingNew => existingNew._id == new2._id);
            news[index] = new2;
            await Task.CompletedTask;

        }

        public async Task DeleteNewAsync(Guid iDNew)
        {
            var index = news.FindIndex(existingNew => existingNew._id == iDNew);
            news.RemoveAt(index);
            await Task.CompletedTask;
        }

        public async Task OkeyUpdateNewAsync(New new2)
        {
            var index = news.FindIndex(existingNew => existingNew._id == new2._id);
            news[index] = new2;
            await Task.CompletedTask;
        }

        public async Task DeleteNewFalseAsync(Guid idNeww)
        {
            var index = news.FindIndex(existingNew => existingNew._id == idNeww);
            news.RemoveAt(index);
            await Task.CompletedTask;
        }
    }
}