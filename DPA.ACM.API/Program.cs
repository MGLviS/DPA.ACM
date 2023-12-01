using AutoMapper;
using DPA.ACM.DOMAIN.Core.Interfaces;
using DPA.ACM.DOMAIN.Core.Services;
using DPA.ACM.DOMAIN.Infrastructure.Data;
using DPA.ACM.DOMAIN.Infrastructure.Mapping;
using DPA.ACM.DOMAIN.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var _config = builder.Configuration; //obtener atributos de la cadena de conexion
var _cnx = _config.GetConnectionString("DevConnection"); // cadena de conexi�n
builder.Services.AddDbContext<AutoCareManagerContext>(options =>
{
options.UseSqlServer(_cnx);
});

//Gestion Propietario
builder
    .Services.
    AddTransient<IPropietarioRepository, PropietarioRepository>();
builder.Services.AddTransient<IPropietarioService, PropietarioService>();

//Gestion Taller
builder
    .Services.
    AddTransient<ITallerRepository, TallerRepository>();
builder.Services.AddTransient<ITallerService, TallerService>();

//Gestion Mecanico
builder
    .Services.
    AddTransient<IMecanicoRepository, MecanicoRepository>();
builder.Services.AddTransient<IMecanicoService, MecanicoService>();

//Inventario Repuestos

builder
    .Services
    .AddTransient<IInventarioRepository, InventarioRepository>();
builder.Services.AddTransient<IInventarioService, InventarioService>();

//Gestion Cliente
builder
    .Services
    .AddTransient<IClienteRepository, ClienteRepository>();
builder.Services.AddTransient<IClienteService, ClienteService>();

//Gestion Factura
builder
    .Services
    .AddTransient<IFacturaRepository, FacturaRepository>();
builder.Services.AddTransient<IFacturaService, FacturaService>();

//Detalle Factura
builder
    .Services
    .AddTransient<IDetFacturaRepository, DetFacturaRepository>();
builder.Services.AddTransient<IDetFacturaService, DetFacturaService>();

//Gestion Servicio
builder
    .Services
    .AddTransient<IServicioRepository, ServicioRepository>();
builder.Services.AddTransient<IServicioService, ServicioService>();

//Gestion Vehiculo
builder
    .Services
    .AddTransient<IVehiculoRepository, VehiculoRepository>();
builder.Services.AddTransient<IVehiculoService, VehiculoService>();

//Detalle Inventario
builder
    .Services
    .AddTransient<IDetalleInvRepository, DetalleInvRepository>();
builder.Services.AddTransient<IDetInvService,DetInvService>();

//Reparacion Mantenimiento
builder
    .Services
    .AddTransient<IDetalleMantRepository, DetalleMantRepository>();
builder.Services.AddTransient<IDetalleMantService, DetalleMantService>();

//Add Automapper
var config = new MapperConfiguration(cfg =>
{
    cfg.AddProfile(new AutomapperProfile());
}
);
var mapper = config.CreateMapper();

builder.Services.AddControllers();
builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(builder =>
    {
        builder.AllowAnyOrigin()
               .AllowAnyHeader()
               .AllowAnyMethod();

    });
});
builder.Services.AddSingleton(mapper);

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();
app.UseCors();
app.MapControllers();

app.Run();
