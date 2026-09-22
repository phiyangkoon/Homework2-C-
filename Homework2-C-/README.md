# ศึกผลัดตา (Turn-based Battle) — Blazor WebAssembly

เกมต่อสู้แบบผลัดตาเขียนด้วย C# ล้วน รันบนเว็บผ่าน Blazor WebAssembly (.NET 8)

## สิ่งที่ต้องติดตั้งก่อน

1. **.NET 8 SDK** — ดาวน์โหลดที่ https://dotnet.microsoft.com/download/dotnet/8.0
2. ติดตั้ง workload สำหรับ WebAssembly (ครั้งแรกครั้งเดียว):
   ```bash
   dotnet workload install wasm-tools
   ```

## วิธีรัน

เปิด Terminal ในโฟลเดอร์นี้ แล้วรัน:

```bash
dotnet restore
dotnet run
```

จากนั้นเปิดเบราว์เซอร์ไปที่ลิงก์ที่ขึ้นในคอนโซล (ปกติจะเป็น `https://localhost:7050`) เบราว์เซอร์จะเปิดให้อัตโนมัติอยู่แล้ว

## โครงสร้างโปรเจกต์

```
TurnBasedRPG/
├── Program.cs              จุดเริ่มต้นแอป ลงทะเบียน service
├── App.razor                Router หลัก
├── MainLayout.razor         โครง layout
├── Models/
│   ├── Character.cs         สถานะตัวละคร (HP/MP/ATK/DEF/SPD)
│   ├── Skill.cs              สกิล/เวทมนตร์
│   ├── Item.cs                ไอเทมใช้ในการต่อสู้
│   └── BattleLogEntry.cs    บันทึกเหตุการณ์การต่อสู้
├── Services/
│   └── BattleService.cs     ตรรกะเกมทั้งหมด (turn order, AI ศัตรู, เงื่อนไขจบเกม)
├── Pages/
│   ├── Battle.razor          หน้าเกมหลัก
│   └── CharacterCard.razor  การ์ดแสดง HP/MP
└── wwwroot/
    ├── index.html
    └── css/app.css
```

## กลไกเกมที่ทำไว้

- **ระบบผลัดตาจริง**: ใครมีค่า Speed สูงกว่าจะได้ลงมือก่อนในแต่ละรอบ
- **การกระทำของผู้เล่น**: โจมตีธรรมดา, ป้องกัน (ลดดาเมจ 50%), ใช้สกิล (มีทั้งสายโจมตีและสายฮีล), ใช้ไอเทม
- **AI ศัตรูเบื้องต้น**: ถ้า HP ต่ำกว่า 25% มีโอกาสตั้งการ์ดป้องกันแทนการโจมตี
- **3 ด่าน** ความยากเพิ่มขึ้นเรื่อย ๆ ผ่านครบเจอหน้าจอชัยชนะสมบูรณ์
- แพ้แล้วกดเริ่มใหม่ได้ทันที

## ต่อยอดได้ง่าย

- เพิ่มศัตรูใหม่: แก้ `_enemyRoster` ใน `BattleService.cs`
- เพิ่มสกิล/ไอเทมใหม่: แก้ constructor ของ `BattleService`
- ปรับดีไซน์: แก้ `wwwroot/css/app.css`
- อยาก deploy ขึ้นเว็บจริง: publish เป็น static files แล้วโฮสต์บน GitHub Pages, Azure Static Web Apps, หรือ Netlify ได้เลย (`dotnet publish -c Release`)
