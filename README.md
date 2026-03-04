# Inventory_Management
📖 Giới thiệu
- Inventory Management System là ứng dụng quản lý kho được phát triển bằng WPF (.NET) kết hợp với Entity Framework Core và SQL Server.
- Hệ thống cho phép quản lý sản phẩm, thực hiện nhập/xuất kho và theo dõi lịch sử giao dịch.
- Dự án được xây dựng theo mô hình 3-Layer Architecture (Model – DAL – BLL) nhằm đảm bảo cấu trúc rõ ràng, dễ bảo trì và mở rộng.

🎯 Mục tiêu dự án
- Ứng dụng kiến thức WPF và Entity Framework vào thực tế
- Triển khai mô hình kiến trúc 3 tầng
- Xây dựng logic nghiệp vụ quản lý kho
- Thực hành validation và xử lý dữ liệu với SQL Server

🏗 Kiến trúc hệ thống
UI (WPF)
   ↓
BLL (Business Logic Layer)
   ↓
DAL (Data Access Layer)
   ↓
Database (SQL Server)

🚀 Chức năng chính
1️⃣ Quản lý sản phẩm
- Thêm sản phẩm
- Cập nhật thông tin
- Xóa sản phẩm
- Hiển thị danh sách bằng DataGrid

2️⃣ Nhập kho (Import)
- Tăng số lượng tồn
- Lưu lịch sử giao dịch

3️⃣ Xuất kho (Export)
- Giảm số lượng tồn
- Không cho phép xuất vượt quá tồn kho
- Lưu lịch sử giao dịch

🧠 Business Logic nổi bật
 - Không cho phép nhập/xuất số lượng ≤ 0
 - Không cho phép xuất vượt quá số lượng tồn
 - Mỗi giao dịch đều được lưu vào bảng Transactions
 - Validation được xử lý tại tầng BLL
 - Tách biệt rõ ràng giữa UI – Logic – Data

⚙️ Công nghệ sử dụng
- .NET (WPF)
- C#
- Entity Framework Core
- SQL Server
- 3-Layer Architecture

🛠 Hướng dẫn chạy project
1. Clone repository
2. Mở bằng Visual Studio
3. Cấu hình chuỗi kết nối trong appsettings.json
4. Tạo Database bằng SQL Server
5. Chạy project

📈 Hướng phát triển tương lai
- Thêm chức năng tìm kiếm sản phẩm
- Xem lịch sử giao dịch theo từng sản phẩm
- Thống kê tổng nhập/xuất
- Thêm phân quyền người dùng
- Chuyển sang mô hình MVVM
