namespace AvMonitor.Models
{
    public class UserModel
    {
        public string? Name { get; private set; }

        public UserModel(string name)
        {
            Name = name;
        }


        //сюда вставить можно ещё что-нибудь, чё там у пользователя есть

    }
}
