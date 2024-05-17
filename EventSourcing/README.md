### Event Sourcing là một kỹ thuật trong lập trình phần mềm mà trạng thái của một đối tượng được lưu trữ dưới dạng chuỗi các sự kiện đã xảy ra với đối tượng đó. Mỗi sự kiện mô tả một thay đổi trạng thái, và trạng thái hiện tại của đối tượng có thể được xác định bằng cách phát lại các sự kiện này.

Các khái niệm cơ bản
```
1. Event (Sự kiện): Một sự kiện đại diện cho một hành động hoặc thay đổi đã xảy ra trong hệ thống.

2. Event Store: Kho lưu trữ các sự kiện. Thường là một cơ sở dữ liệu hoặc một dịch vụ lưu trữ sự kiện.

3. Aggregate: Một đơn vị logic bao gồm các thực thể và giá trị mà hoạt động như một đơn vị duy nhất liên quan đến thay đổi trạng thái và tính toàn vẹn.

4. Command (Lệnh): Một yêu cầu thực hiện một hành động cụ thể dẫn đến sự thay đổi trạng thái của hệ thống.

5. Event Handler: Thành phần xử lý sự kiện để thay đổi trạng thái hoặc thực hiện các tác vụ khác.
```

Event Sourcing giúp dễ dàng theo dõi và tái hiện lại lịch sử của đối tượng, cung cấp một cách tiếp cận mạnh mẽ để quản lý trạng thái phức tạp trong các hệ thống phân tán hoặc yêu cầu tính toàn vẹn dữ liệu cao.
