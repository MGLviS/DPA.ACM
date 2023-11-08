using DPA.ACM.DOMAIN.Core.Interfaces;
using DPA.ACM.DOMAIN.Core.Services;
using DPA.ACM.DOMAIN.Infrastructure.Data;
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

//Gestion Taller
builder
    .Services.
    AddTransient<ITallerRepository, TallerRepository>();

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


builder.Services.AddControllers();
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

app.MapControllers();

app.Run();
