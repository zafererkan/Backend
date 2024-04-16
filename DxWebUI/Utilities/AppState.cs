namespace DxWebUI.Utilities
{
    public class AppState
    {
        public event Action OnChange = default!;
       // public PersonelDto? PersonelDto;

        //public void SendPersonelId(PersonelDto? PersonelDto)
        //{
        //    this.PersonelDto = PersonelDto;
        //    NotifyStateChanged();
        //}
        //public void SendMessageToChat2(string message)
        //{
        //    messages2.Add(message);
        //    NotifyStateChanged();
        //}

        private void NotifyStateChanged() => OnChange?.Invoke();
    }
}
