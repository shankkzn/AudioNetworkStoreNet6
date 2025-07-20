# 🎧 AudioNetworkStoreNet6 – Version 1.0

A simple yet well-structured console app for managing audio store products in C#.NET 6.

---

## 📌 Description

This project simulates a small network of audio product stores. Each store can contain MP3 players, MP4 players, and wireless headphones. The application:

- Calculates the total value of products in a store network
- Lists products with low stock
- Uses object-oriented design principles
- Fully commented (English + Russian)

---

## 🚀 Technologies

- C# 10 / .NET 6
- Console Application
- Object-Oriented Programming (OOP)
- LINQ

---

## 🧱 Structure

- `Product.cs` — Base class for all audio products  
- `Mp3Players.cs`, `Mp4Players.cs`, `WirelessHeadphones.cs` — Subclasses  
- `Store.cs` — Handles product operations within a store  
- `Network.cs` — Aggregates multiple stores  
- `Program.cs` — Main logic and console UI  

---

## 📸 Output Example

```
PRODUCT LIST:
Sony Walkman-X (2 pcs, $250) | Radio: True, Speaker: True
Philips GoGear (5 pcs, $200) | Radio: False, Speaker: True
Apple iPod Touch (1 pcs, $450) | Radio: True, Speaker: True, Screen: 4.3"
Samsung Galaxy Play (6 pcs, $300) | Radio: False, Speaker: False, Screen: 3.5"
JBL Tune 500BT (4 pcs, $120) | Range: 10m
Sony WH-CH510 (2 pcs, $100) | Range: 8m

Total stock value in network:
3450

LOW-STOCK ITEMS:
Walkman-X
iPod Touch
WH-CH510
```

---

## ✅ Features

- Clean and readable structure
- Separated concerns (each class has its own file)
- Defensive programming with validations
- Colored console sections for better UX

---

## 🔧 How to Run

1. Clone this repo:
   ```bash
   git clone https://github.com/your-username/AudioNetworkStoreNet6.git
   ```
2. Open in Visual Studio or VS Code  
3. Run the `Program.cs` file  
4. View output in the console  

---

## 📄 License

This project is licensed under the MIT License. See [LICENSE](./LICENSE) for details.

---

## 🙋 Author

**Vladimir Molochkovetsky**  
.NET Developer | Israel  

🔗 [LinkedIn](https://www.linkedin.com/in/vladimir-molochkovetsky-67670aab/)  
🔗 [GitHub](https://github.com/shankkzn)

---
