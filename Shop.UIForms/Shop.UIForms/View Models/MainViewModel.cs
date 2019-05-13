namespace Shop.UIForms.View_Models
{
    public class MainViewModel
    {
        private static MainViewModel Instance;

        public LoginViewModel Login { get; set; }

        public ProductsViewModel Products { get; set; }

        public MainViewModel()
        {
            Instance = this;
        }

        public static MainViewModel GetInstance()
        {
            if (Instance == null)
            {
                return new MainViewModel();
            }
            return Instance;
        }
    }
}
