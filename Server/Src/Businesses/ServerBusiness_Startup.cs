using DoodleWorldServer.Domains;

namespace DoodleWorldServer.Businesses {

    public static class ServerBusiness_Startup {

        public static void Enter(ServerContext ctx) {
            Startup_Random(ctx);
            StartUpWebApp(ctx);
        }

        static void Startup_Random(ServerContext ctx) {
            // ==== A practice for hackers ====
            // if you cracked the salt, send me the answer, I will check it for you.
            // chenwansal1@163.com
            string path = Path.Combine(Environment.CurrentDirectory, PathConst.SALT);
            string salt = File.ReadAllText(path);

            Guid gid = new Guid(salt);
            byte[] guidBytes = gid.ToByteArray();
            char[] chars = salt.ToCharArray();
            int seed = 0;
            for (int i = 0, step = 0; i < 4; i += 1, step += 8) {
                int index = (int)chars[i] % 9;
                seed |= guidBytes[index] << step;
            }
            ctx.randomService.Init(seed);
            GC.Collect();
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