using website.Dtos;
using website.Entities;

namespace website
{
    public static class Extensions
    {
        public static AccountDto AsDtoAccount(this Account account)
        {
            return new AccountDto
            {
                idAc = account._id,
                uname = account.uname,
                pass = account.pass,
                idPo = account.idPo
            };
        }
        public static ImageDto AsDtoImage(this Image image)
        {
            return new ImageDto()
            {
                idIma = image._id,
                srcIma = image.srcIma,
                idNew = image.idNew
            };
        }
        public static NewDto AsDtoNew(this New new2)
        {
            return new NewDto()
            {
                idNew = new2._id,
                title = new2.title,
                description = new2.description,
                content = new2.content,
                status = new2.status,
                idImage = new2.idImage,
                idTop = new2.idTop,
                idAc = new2.idAc,
                creatDate = new2.creatDate

            };
        }
        public static NewDto AsDtoNewTrue(this New new2)
        {

            return new NewDto()
            {
                idNew = new2._id,
                title = new2.title,
                description = new2.description,
                content = new2.content,
                // status = true,
                status = true,
                idImage = new2.idImage,
                idTop = new2.idTop,
                idAc = new2.idAc,
                creatDate = new2.creatDate

            };
        }
        public static NewDto AsDtoNewFalse(this New new2)
        {

            return new NewDto()
            {
                idNew = new2._id,
                title = new2.title,
                description = new2.description,
                content = new2.content,
                status = false,
                // status = new2.status,
                idImage = new2.idImage,
                idTop = new2.idTop,
                idAc = new2.idAc,
                creatDate = new2.creatDate

            };
        }
        public static PositionDto AsDtoPosition(this Position position)
        {
            return new PositionDto()
            {
                idPo = position._id,
                namePo = position.namePo
            };
        }
        public static ReasonDto AsDtoReason(this Reason reason)
        {
            return new ReasonDto()
            {
                idRea = reason._id,
                idNew = reason.idNew,
                contentRea = reason.contentRea
            };
        }
        public static TopicDto AsDtoTopic(this Topic topic)
        {
            return new TopicDto()
            {
                idTop = topic._id,
                nameTop = topic.nameTop
            };
        }
        public static UserDto AsDtoUser(this User user)
        {
            return new UserDto()
            {
                //ten hien thi = user. ten truyen vao ten de hien thi
                idUser = user._id,
                name = user.name,
                email = user.email,
                sdt = user.sdt,
                idAc = user.idAc
            };
        }

    }
}
