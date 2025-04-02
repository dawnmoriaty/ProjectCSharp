# Cấu Trúc Database

## Các Bảng và Mối Quan Hệ

### 1. TransactionCategory (Bảng Danh Mục Giao Dịch)
- **Mô tả**: Lưu trữ các danh mục cho các giao dịch
- **Thuộc tính**:
  - `Id`: Khóa chính, định danh duy nhất cho danh mục
  - `Name`: Tên danh mục (ví dụ: Lương, Ăn uống, Di chuyển...)
  - `Description`: Mô tả chi tiết về danh mục
  - `Type`: Loại danh mục (INCOME/EXPENSE) - Thu nhập hoặc Chi tiêu
  - `IsDefault`: Đánh dấu danh mục mặc định (true/false)
  - `CreatedDate`: Ngày tạo danh mục
- **Quan hệ**:
  - Có quan hệ một-nhiều với bảng Transaction (một danh mục có thể có nhiều giao dịch)

### 2. Transaction (Bảng Giao Dịch)
- **Mô tả**: Lưu trữ thông tin về các giao dịch tài chính
- **Thuộc tính**:
  - `Id`: Khóa chính, định danh duy nhất cho giao dịch
  - `BudgetId`: Khóa ngoại liên kết với bảng Budget
  - `UserId`: Khóa ngoại liên kết với bảng User
  - `CategoryId`: Khóa ngoại liên kết với bảng TransactionCategory
  - `Amount`: Số tiền giao dịch
  - `Type`: Loại giao dịch (INCOME/EXPENSE) - Thu nhập hoặc Chi tiêu
  - `Description`: Mô tả chi tiết về giao dịch
  - `TransactionDate`: Ngày thực hiện giao dịch
  - `CreatedDate`: Ngày tạo giao dịch trong hệ thống
  - `Status`: Trạng thái giao dịch (COMPLETED/PENDING/CANCELLED)
  - `Location`: Địa điểm giao dịch (tùy chọn)
  - `Attachment`: Đường dẫn đến file đính kèm (tùy chọn)
- **Quan hệ**:
  - Thuộc về một Budget (nhiều-một)
  - Thuộc về một User (nhiều-một)
  - Thuộc về một TransactionCategory (nhiều-một)

### 3. Budget (Bảng Ngân Sách)
- **Mô tả**: Quản lý ngân sách cho các giao dịch
- **Thuộc tính**:
  - `Id`: Khóa chính, định danh duy nhất cho ngân sách
  - `UserId`: Khóa ngoại liên kết với bảng User
  - `BudgetName`: Tên ngân sách
  - `Amount`: Số tiền ngân sách
  - `Currency`: Đơn vị tiền tệ (mặc định: VND)
  - `StartDate`: Ngày bắt đầu ngân sách
  - `EndDate`: Ngày kết thúc ngân sách
  - `CreatedDate`: Ngày tạo ngân sách
  - `LastUpdatedDate`: Ngày cập nhật gần nhất
- **Quan hệ**:
  - Thuộc về một User (nhiều-một)
  - Có quan hệ một-nhiều với bảng Transaction (một ngân sách có thể có nhiều giao dịch)

### 4. User (Bảng Người Dùng)
- **Mô tả**: Lưu trữ thông tin người dùng
- **Thuộc tính**:
  - `Id`: Khóa chính, định danh duy nhất cho người dùng
  - `UserName`: Tên đăng nhập
  - `PasswordHash`: Mật khẩu đã được mã hóa
  - `Email`: Email người dùng
  - `FullName`: Họ tên đầy đủ
  - `CreatedDate`: Ngày tạo tài khoản
  - `UserRole`: Vai trò người dùng (USER/ADMIN)
  - `Status`: Trạng thái tài khoản (ACTIVE/INACTIVE/BLOCKED)
- **Quan hệ**:
  - Có quan hệ một-nhiều với bảng Budget (một người dùng có thể có nhiều ngân sách)
  - Có quan hệ một-nhiều với bảng Transaction (một người dùng có thể có nhiều giao dịch)

## Sơ Đồ Quan Hệ
```
User
  ↓
  ├── Budget (1:N)
  │     ↓
  │     └── Transaction (1:N)
  └── TransactionCategory (1:N)
        ↓
        └── Transaction (1:N)
```

## Luồng Hoạt Động Quản Lý Chi Tiêu Cá Nhân

### 1. Đăng Ký và Đăng Nhập
- Người dùng tạo tài khoản mới trong hệ thống
- Thông tin người dùng được lưu vào bảng `User`
- Người dùng đăng nhập vào hệ thống

### 2. Thiết Lập Ngân Sách
- Sau khi đăng nhập, người dùng tạo ngân sách mới
- Hệ thống tạo bản ghi mới trong bảng `Budget` với thông tin:
  - Tên ngân sách
  - Số tiền ngân sách
  - Thời gian áp dụng (ngày bắt đầu và kết thúc)
  - Đơn vị tiền tệ

### 3. Thiết Lập Danh Mục
- Người dùng có thể sử dụng các danh mục mặc định hoặc tạo danh mục mới
- Mỗi danh mục được phân loại là thu nhập (INCOME) hoặc chi tiêu (EXPENSE)
- Thông tin danh mục được lưu vào bảng `TransactionCategory`

### 4. Quản Lý Giao Dịch
- **Thêm giao dịch mới**:
  1. Người dùng nhập thông tin giao dịch: số tiền, danh mục, ngày, mô tả...
  2. Hệ thống tạo bản ghi mới trong bảng `Transaction`
  3. Cập nhật số dư ngân sách: 
     - Nếu là thu nhập: tăng số dư
     - Nếu là chi tiêu: giảm số dư
  
- **Chỉnh sửa giao dịch**:
  1. Người dùng thay đổi thông tin của giao dịch
  2. Hệ thống cập nhật bản ghi trong bảng `Transaction`
  3. Điều chỉnh số dư ngân sách: tính toán sự chênh lệch giữa giá trị cũ và mới
  
- **Xóa giao dịch**:
  1. Người dùng chọn xóa giao dịch
  2. Hệ thống xóa bản ghi trong bảng `Transaction`
  3. Điều chỉnh số dư ngân sách: hoàn trả lại số tiền tương ứng

### 5. Báo Cáo và Thống Kê
- Tổng hợp dữ liệu từ các giao dịch để tạo báo cáo
- Thống kê thu chi theo danh mục, thời gian
- Đánh giá tình hình tài chính dựa trên kế hoạch ngân sách

## Ví Dụ Chi Tiết

### Ví dụ 1: Thiết lập ngân sách hàng tháng

```csharp
// Tạo ngân sách mới
BudgetDAO budgetDAO = new BudgetDAO();
int userId = 1;
string budgetName = "Ngân sách tháng 5/2023";
decimal amount = 10000000; // 10 triệu VND
DateTime startDate = new DateTime(2023, 5, 1);
DateTime endDate = new DateTime(2023, 5, 31);

string result = budgetDAO.CreateBudget(userId, budgetName, amount, startDate, endDate);
// Kết quả: "Tạo ngân sách thành công"

// Dữ liệu trong bảng Budget:
// Id: 1
// UserId: 1
// BudgetName: "Ngân sách tháng 5/2023"
// Amount: 10000000
// Currency: "VND"
// StartDate: 2023-05-01
// EndDate: 2023-05-31
// CreatedDate: 2023-05-01 10:30:00
// LastUpdatedDate: null
```

### Ví dụ 2: Thêm giao dịch thu nhập

```csharp
// Thêm giao dịch lương tháng
TransactionDAO transactionDAO = new TransactionDAO();
int budgetId = 1;
int userId = 1;
int categoryId = 1; // Danh mục "Lương"
decimal amount = 15000000; // 15 triệu VND
string type = "INCOME";
string description = "Lương tháng 5/2023";
DateTime transactionDate = new DateTime(2023, 5, 5);

string result = transactionDAO.CreateTransaction(
    budgetId, userId, categoryId, amount, type, 
    description, transactionDate
);
// Kết quả: "Tạo giao dịch thành công"

// Dữ liệu trong bảng Transaction:
// Id: 1
// BudgetId: 1
// UserId: 1
// CategoryId: 1
// Amount: 15000000
// Type: "INCOME"
// Description: "Lương tháng 5/2023"
// TransactionDate: 2023-05-05
// Status: "COMPLETED"
// CreatedDate: 2023-05-05 09:15:00

// Ngân sách được cập nhật:
// Amount: 25000000 (10000000 + 15000000)
// LastUpdatedDate: 2023-05-05 09:15:00
```

### Ví dụ 3: Thêm giao dịch chi tiêu

```csharp
// Thêm giao dịch chi tiêu ăn uống
int budgetId = 1;
int userId = 1;
int categoryId = 2; // Danh mục "Ăn uống"
decimal amount = 200000; // 200 nghìn VND
string type = "EXPENSE";
string description = "Ăn tối nhà hàng";
DateTime transactionDate = new DateTime(2023, 5, 6);
string location = "Nhà hàng ABC";

string result = transactionDAO.CreateTransaction(
    budgetId, userId, categoryId, amount, type, 
    description, transactionDate, location
);
// Kết quả: "Tạo giao dịch thành công"

// Dữ liệu trong bảng Transaction:
// Id: 2
// BudgetId: 1
// UserId: 1
// CategoryId: 2
// Amount: 200000
// Type: "EXPENSE"
// Description: "Ăn tối nhà hàng"
// TransactionDate: 2023-05-06
// Location: "Nhà hàng ABC"
// Status: "COMPLETED"
// CreatedDate: 2023-05-06 20:30:00

// Ngân sách được cập nhật:
// Amount: 24800000 (25000000 - 200000)
// LastUpdatedDate: 2023-05-06 20:30:00
```

### Ví dụ 4: Chỉnh sửa giao dịch

```csharp
// Chỉnh sửa giao dịch chi tiêu
int transactionId = 2;
decimal newAmount = 250000; // 250 nghìn VND thay vì 200 nghìn
string newDescription = "Ăn tối nhà hàng cùng đồng nghiệp";
DateTime transactionDate = new DateTime(2023, 5, 6);
string location = "Nhà hàng ABC";

string result = transactionDAO.UpdateTransaction(
    transactionId, newAmount, newDescription, 
    transactionDate, location
);
// Kết quả: "Cập nhật giao dịch thành công"

// Dữ liệu trong bảng Transaction được cập nhật:
// Id: 2
// Amount: 250000
// Description: "Ăn tối nhà hàng cùng đồng nghiệp"

// Ngân sách được cập nhật:
// Amount: 24750000 (24800000 - 50000)
// LastUpdatedDate: 2023-05-07 10:15:00
```

### Ví dụ 5: Xóa giao dịch

```csharp
// Xóa giao dịch chi tiêu
int transactionId = 2;

string result = transactionDAO.DeleteTransaction(transactionId);
// Kết quả: "Xóa giao dịch thành công"

// Bản ghi trong bảng Transaction đã bị xóa

// Ngân sách được cập nhật:
// Amount: 25000000 (24750000 + 250000)
// LastUpdatedDate: 2023-05-07 11:00:00
```

## Lưu ý
- Tất cả các bảng đều có trường `CreatedDate` để theo dõi thời gian tạo
- Các quan hệ được thiết lập thông qua khóa ngoại (Foreign Key)
- Mỗi giao dịch phải thuộc về một danh mục
- Mỗi ngân sách phải được liên kết với một người dùng
- Mỗi người dùng có thể có nhiều giao dịch, danh mục và ngân sách
- Khi thay đổi hoặc xóa giao dịch, số dư ngân sách sẽ được tự động cập nhật
- Các thao tác thêm/sửa/xóa giao dịch đều được thực hiện trong transactions SQL để đảm bảo tính nhất quán của dữ liệu 