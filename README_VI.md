# Cấu trúc Dự án Game RPG Unity

## Giới thiệu
Đây là cấu trúc cơ bản của một dự án game RPG được xây dựng bằng Unity. Project bao gồm các hệ thống cốt lõi cần thiết để phát triển một game nhập vai.

## Cấu trúc Thư mục

```
stub-game/
├── Assets/
│   ├── Scenes/              # Các scene trong game
│   ├── Scripts/             # Code C#
│   │   ├── Player/          # Script điều khiển người chơi
│   │   ├── Enemy/           # Script AI kẻ địch
│   │   ├── Combat/          # Hệ thống chiến đấu
│   │   ├── Inventory/       # Hệ thống túi đồ
│   │   ├── Items/           # Định nghĩa vật phẩm
│   │   ├── Managers/        # Quản lý game
│   │   └── UI/              # Giao diện người dùng
│   ├── Prefabs/             # Các đối tượng có thể tái sử dụng
│   ├── Materials/           # Vật liệu và shader
│   ├── Textures/            # Hình ảnh và sprite
│   ├── Audio/               # Âm thanh và nhạc nền
│   └── UI/                  # Tài nguyên UI
└── ProjectSettings/         # Cài đặt Unity
```

## Các Hệ thống Chính

### 1. Hệ thống Nhân vật (Player System)
- **PlayerController.cs**: Điều khiển di chuyển nhân vật
  - Di chuyển bằng WASD hoặc phím mũi tên
  - Chạy bằng cách giữ phím Shift
  - Tích hợp với Animator cho animation

- **CharacterStats.cs**: Quản lý chỉ số nhân vật
  - HP (máu), MP (mana), Tấn công, Phòng thủ
  - Hệ thống cấp độ và kinh nghiệm
  - Hồi máu, nhận sát thương, lên cấp

### 2. Hệ thống Kẻ địch (Enemy System)
- **EnemyAI.cs**: Trí tuệ nhân tạo cơ bản
  - Tuần tra, phát hiện và đuổi theo người chơi
  - Tấn công khi trong tầm
  - Nhiều trạng thái: Idle, Patrol, Chase, Attack

### 3. Hệ thống Chiến đấu (Combat System)
- **CombatSystem.cs**: Tính toán sát thương
  - Công thức damage: (Attack × multiplier) - Defense
  - Tỷ lệ trúng đòn và chí mạng
  - Singleton để truy cập toàn cục

### 4. Hệ thống Túi đồ (Inventory System)
- **InventorySystem.cs**: Quản lý vật phẩm
  - Thêm/xóa vật phẩm
  - Hệ thống stack cho items
  - Sử dụng vật phẩm

- **Item.cs**: Class cơ sở cho vật phẩm
  - Dùng ScriptableObject
  - Loại vật phẩm: Tiêu hao, Vũ khí, Áo giáp, Quest

- **Potion.cs**: Vật phẩm hồi phục
  - Hồi HP và MP
  - Tự động áp dụng cho người chơi

### 5. Hệ thống Quest
- **Quest.cs**: Nhiệm vụ và phần thưởng
  - Theo dõi tiến độ nhiệm vụ
  - Phần thưởng kinh nghiệm và vật phẩm
  - Tự động kiểm tra hoàn thành

### 6. Hệ thống UI
- **HealthManaUI.cs**: Hiển thị máu và mana
  - Thanh HP và MP
  - Hiển thị số
  - Tự động cập nhật

### 7. Game Manager
- **GameManager.cs**: Quản lý game
  - Tạm dừng/tiếp tục (phím ESC)
  - Chuyển scene
  - Singleton pattern

## Hướng dẫn Bắt đầu

### Yêu cầu
- Unity 2019.4 LTS hoặc mới hơn
- Kiến thức cơ bản về C# và Unity

### Các bước Setup
1. Clone repository này
2. Mở project trong Unity
3. Mở scene `MainScene` trong `Assets/Scenes/`
4. Tạo GameObject cho người chơi và gắn:
   - PlayerController
   - CharacterStats
   - InventorySystem
   - Rigidbody2D
5. Tạo GameObject cho kẻ địch và gắn:
   - EnemyAI
   - CharacterStats
6. Đặt tag "Player" cho nhân vật chính
7. Đặt tag "Enemy" cho kẻ địch

### Phím điều khiển
- **WASD / Phím mũi tên**: Di chuyển
- **Shift trái**: Chạy (giữ khi di chuyển)
- **ESC**: Tạm dừng/Tiếp tục

## Tạo Vật phẩm Mới

1. Click chuột phải trong cửa sổ Project
2. Chọn `Create > RPG > Item` hoặc `Create > RPG > Items > Potion`
3. Cấu hình thuộc tính trong Inspector
4. Thêm vào inventory: `inventory.AddItem(item);`

## Tạo Quest Mới

1. Click chuột phải trong cửa sổ Project
2. Chọn `Create > RPG > Quest`
3. Cấu hình tên, mô tả, mục tiêu và phần thưởng

## Mở rộng Project

### Thêm loại vật phẩm mới
1. Tạo class kế thừa từ `Item`
2. Override method `Use()`
3. Thêm thuộc tính tùy chỉnh

### Thêm hành vi kẻ địch mới
1. Kế thừa class `EnemyAI`
2. Thêm state mới vào state machine
3. Implement pattern tấn công riêng

### Thêm kỹ năng
1. Tạo ScriptableObject `Skill`
2. Thêm chi phí mana và hiệu ứng
3. Tích hợp với `CharacterStats`

## Tags Unity cần thiết
- **Player**: Cho GameObject người chơi
- **Enemy**: Cho kẻ địch
- **NPC**: Cho nhân vật không người chơi
- **Item**: Cho vật phẩm nhặt được

## Layers Unity
- **Layer 8**: Player
- **Layer 9**: Enemy
- **Layer 10**: Ground (Mặt đất)
- **Layer 11**: Interactable (Tương tác)

## Tính năng Tương lai
- [ ] Hệ thống đối thoại
- [ ] Save/Load game
- [ ] Nhiều loại kẻ địch
- [ ] Hệ thống trang bị
- [ ] Cây kỹ năng
- [ ] Âm thanh và nhạc nền
- [ ] UI nâng cao
- [ ] Bản đồ nhỏ
- [ ] Hệ thống thành tích

## Hỗ trợ
Nếu gặp vấn đề, vui lòng tham khảo file DEVELOPMENT_GUIDE.md để biết thêm chi tiết và giải pháp.
