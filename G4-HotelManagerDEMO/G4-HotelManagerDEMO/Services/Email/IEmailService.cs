namespace G4_HotelManagerDEMO.Services.Email
{
    public interface IEmailService
    {
        void SendEmail(string emailTo, string recepientName, string subject, string body);
    }
}
