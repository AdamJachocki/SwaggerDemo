namespace SwaggerDemo.Models
{
    public class User
    {
        /// <summary>
        /// Id użytkownika
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// Imię i nazwisko użytkownika. Uwaga! Pole może być puste
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// E-mail użytkownika
        /// </summary>
        public string Email { get; set; }
        /// <summary>
        /// Hasło użytkownika. Zawsze puste, gdy pobieramy rekord.
        /// </summary>
        public string Password { get; set; }
    }
}
