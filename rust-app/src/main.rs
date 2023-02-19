use actix_web::{web, App, HttpResponse, HttpServer};
use serde::{Serialize, Deserialize};

#[derive(Serialize, Deserialize)]
struct Device {
    id: i32,
    mac: String,
    firmware: String,
}

fn fibonacci(n: u32) -> u32 {
    match n {
        1 | 2 => 1,
        3 => 2,
        _ => fibonacci(n - 1) + fibonacci(n - 2),
    }
}

async fn get_devices() -> HttpResponse {
    let mut devices = Vec::new();

    devices.push(Device {id: 1, mac: String::from("5F-33-CC-1F-43-82"), firmware: String::from("2.1.6")});
    devices.push(Device {id: 2, mac: String::from("EF-2B-C4-F5-D6-34"), firmware: String::from("2.1.6")});

    HttpResponse::Ok().json(devices)
}

async fn create_device() -> HttpResponse {
    let number = 40;

    let fib = fibonacci(number);
    let location = format!("/devices/{}", fib);

    HttpResponse::Created().append_header(("location", location)).finish()
}

#[actix_web::main]
async fn main() -> std::io::Result<()> {
    HttpServer::new(|| {
        App::new()
            .route("/devices", web::get().to(get_devices))
            .route("/devices", web::post().to(create_device))
    })
    .bind("0.0.0.0:8000")?
    .run()
    .await
}