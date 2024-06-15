namespace FlatFleet;

public partial class VerifyEmailPage : ContentPage
{
	public VerifyEmailPage()
	{
		InitializeComponent();
		BindingContext = new Model();
	}
    private void Entry_TextChanged(object sender, TextChangedEventArgs e)
    {
        var entry = sender as Entry;

        if (entry.Text.Length == 1)
        {
            switch (entry)
            {
                case Entry when entry == Entry1:
                    Entry2.Focus();
                    break;
                case Entry when entry == Entry2:
                    Entry3.Focus();
                    break;
                case Entry when entry == Entry3:
                    Entry4.Focus();
                    break;
                case Entry when entry == Entry4:
                    break;
            }
        }
    }
}