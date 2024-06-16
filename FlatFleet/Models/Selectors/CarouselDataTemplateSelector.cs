namespace FlatFleet.Models.Selectors
{
    public class CarouselDataTemplateSelector : DataTemplateSelector
    {
        public DataTemplate ItemTemplate1 { get; set; }
        public DataTemplate ItemTemplate2 { get; set; }
        public DataTemplate ItemTemplate3 { get; set; }
        public DataTemplate ItemTemplate4 { get; set; }

        protected override DataTemplate OnSelectTemplate(object item, BindableObject container)
        {
            var id = ((CarouselItem)item).Id;

            switch (id)
            {
                case 1:
                    return ItemTemplate1;
                case 2:
                    return ItemTemplate2;
                case 3:
                    return ItemTemplate3;
                case 4:
                    return ItemTemplate4;
                default:
                    throw new Exception($"Unknown carousel item template ID: {id}! ID must be between 1 and 4!");
            }
        }
    }
}
