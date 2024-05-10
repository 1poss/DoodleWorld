using DoodleWorldServer.Domains;

namespace DoodleWorldServer.Businesses {

    public static class ServerBusiness_Startup {

        public static void Enter(ServerContext ctx) {
            Startup_Random(ctx);
            StartUpWebApp(ctx);
        }

        static void Startup_Random(ServerContext ctx) {
            string path = Path.Combine(Environment.CurrentDirectory, PathConst.SALT);
            string salt = File.ReadAllText(path);
            bool has = int.TryParse(salt, out int res);
            if (!has) {
                SDebug.Error($"Failed to parse salt: {salt}");
                return;
            }
            ctx.randomService.Init(res);
        }

        static void StartUpWebApp(ServerContext ctx) {
            var server = ctx.serverEntity;
            var builder = WebApplication.CreateBuilder(server.args);

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
            server.app = app;
        }

    }

}