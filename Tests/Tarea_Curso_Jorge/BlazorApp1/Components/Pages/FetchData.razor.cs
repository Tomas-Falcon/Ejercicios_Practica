namespace BlazorApp1.Components.Pages
{
    using BlazorApp1.Services;
    using Microsoft.AspNetCore.Components;

    public partial class FetchData 
    {
        [Inject]
        WeatherForecastService? ForecastService { get; set; }


        private WeatherForecast[] forecasts;

        protected override async Task OnInitializedAsync()
        {
            forecasts = await ForecastService.GetForecastAsync(DateTime.Now);
        }

        protected async Task HandleItemSelected(DayOfWeek day)
        {
            WeatherForecast selectedForecast = forecasts.Where(f =>
            f.Date.DayOfWeek == day).First();
            if (selectedForecast != null)
            {
                selectedForecast.Selected = !selectedForecast.Selected;
            }
        }
    }

}
