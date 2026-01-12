# Hisse Senetleri API Projesi

## 📌 Proje Açıklaması

Bu proje, hisse senetleri üzerine kurulmuş bir **ASP.NET Core Web API** uygulamasıdır. Kullanıcılar sisteme kayıt olabilir, giriş yapabilir, hisse senetlerini listeleyebilir, portföy oluşturabilir ve hisseler hakkında yorum yapabilir. Kimlik doğrulama **JWT (JSON Web Token)** ile sağlanmaktadır.

Proje, katmanlı mimari prensiplerine uygun olarak geliştirilmiştir ve **Repository Pattern** kullanılmıştır.

---

## 🏗️ Mimari Diyagram

```
Client (Postman / Frontend)
        |
        v
Controllers (API Layer)
        |
        v
Services / Repositories
        |
        v
Entity Framework Core
        |
        v
SQL Server Database
```

Katmanlar:

* **Controllers**: HTTP isteklerini karşılar
* **Repository**: Veri erişim işlemleri
* **Models / DTOs**: Veri modelleri
* **Context**: EF Core DbContext
* **Services**: JWT ve yardımcı servisler

---

## 🔗 Endpoint Listesi

### 🔐 Account

| Method | Endpoint              | Açıklama         |
| ------ | --------------------- | ---------------- |
| POST   | /api/account/register | Kullanıcı kaydı  |
| POST   | /api/account/login    | Kullanıcı girişi |

### 📈 Stock

| Method | Endpoint        | Açıklama               |
| ------ | --------------- | ---------------------- |
| GET    | /api/stock      | Tüm hisseleri getir    |
| GET    | /api/stock/{id} | ID'ye göre hisse getir |
| POST   | /api/stock      | Yeni hisse ekle        |
| PUT    | /api/stock/{id} | Hisse güncelle         |
| DELETE | /api/stock/{id} | Hisse sil              |

### 💼 Portfolio

| Method | Endpoint            | Açıklama             |
| ------ | ------------------- | -------------------- |
| GET    | /api/portfolio      | Kullanıcı portföyü   |
| POST   | /api/portfolio      | Portföye hisse ekle  |
| DELETE | /api/portfolio/{id} | Portföyden hisse sil |

### 💬 Comment

| Method | Endpoint               | Açıklama                |
| ------ | ---------------------- | ----------------------- |
| GET    | /api/comment/{stockId} | Hisse yorumlarını getir |
| POST   | /api/comment           | Yorum ekle              |
| DELETE | /api/comment/{id}      | Yorum sil               |

---

## 📦 API Response Örnekleri

### 🔑 Login Response

```json
{
  "userName": "emin",
  "email": "emin@example.com",
  "token": "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9..."
}
```

### 📈 Stock Response

```json
{
  "id": 1,
  "symbol": "AAPL",
  "companyName": "Apple Inc.",
  "price": 175.50
}
```

### 💬 Comment Response

```json
{
  "id": 3,
  "content": "Uzun vadede çok güçlü bir hisse",
  "userName": "sueda",
  "stockId": 1
}
```

---

## ⚙️ Kurulum Talimatları

### Gereksinimler

* .NET 7 SDK
* SQL Server
* Visual Studio / VS Code

### Adımlar

1. Projeyi klonlayın:

```bash
git clone https://github.com/kullaniciadi/proje-adi.git
```

2. API klasörüne girin:

```bash
cd Proje/api
```

3. Veritabanı bağlantı cümlesini `appsettings.json` içinde güncelleyin.

4. Migration ve veritabanını oluşturun:

```bash
dotnet ef database update
```

5. Projeyi çalıştırın:

```bash
dotnet run
```

6. Swagger arayüzü:

```
https://localhost:5001/swagger
```

---

## 🧑‍💻 Notlar

* JWT token gerektiren endpointler için `Authorization: Bearer {token}` header'ı eklenmelidir.
* Proje eğitim amaçlı geliştirilmiştir.
