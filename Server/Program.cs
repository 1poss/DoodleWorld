namespace DoodleWorldServer {

    public static class Program {

        public static void Main(string[] args) {

            var builder = WebApplication.CreateBuilder(args);

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment()) {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseRouting();

            app.MapGet("/", (() => {
                return "Hello World!";
            }));

            app.Run();

        }

    }

}
