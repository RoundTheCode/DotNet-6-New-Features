using RoundTheCode.DotNet6;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();

builder.Services.AddSingleton<ITeamService, TeamService>();

builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new() { Title = "RoundTheCode.DotNet6", Version = "v1" });
});

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
    app.UseSwagger();
    app.UseSwaggerUI(c => {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "RoundTheCode.DotNet6 v1");
        c.RoutePrefix = string.Empty;
    });
}
else
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}
app.UseHttpsRedirection();

app.UseRouting();

app.UseAuthorization();

app.MapControllers();

app.MapGet("team/{id}", (ITeamService teamService, int id) => teamService.Read(id));
app.MapPost("team", (ITeamService teamService, Team team) => teamService.Create(team));
app.MapPut("team/{id}", (ITeamService teamService, int id, Team team) => teamService.Update(id, team));
app.MapDelete("team/{id}", (ITeamService teamService, int id) => teamService.Delete(id));

app.Run();