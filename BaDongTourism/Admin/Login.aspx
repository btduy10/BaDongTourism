<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Login.aspx.cs" Inherits="Admin_Login" %>
<!DOCTYPE html>
<html lang="vi">
<head>
    <meta charset="utf-8" />
    <meta name="viewport" content="width=device-width, initial-scale=1.0" />
    <title>Đăng Nhập – Admin Ba Động</title>
    <link href="https://fonts.googleapis.com/css2?family=Nunito:wght@400;600;700;800&display=swap" rel="stylesheet" />
    <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.3.0/dist/css/bootstrap.min.css" rel="stylesheet" />
    <link href="https://cdnjs.cloudflare.com/ajax/libs/font-awesome/6.4.0/css/all.min.css" rel="stylesheet" />
    <style>
        body { font-family:'Nunito',sans-serif; background:linear-gradient(135deg,#0077b6,#00b4d8); min-height:100vh; display:flex; align-items:center; justify-content:center; }
        .login-card { background:white; border-radius:20px; padding:48px 40px; box-shadow:0 20px 60px rgba(0,0,0,0.2); width:100%; max-width:420px; }
        .login-brand { text-align:center; margin-bottom:32px; }
        .login-brand i { font-size:3rem; color:#0077b6; }
        .login-brand h3 { font-weight:800; color:#1a1a2e; margin-top:10px; }
        .login-brand p { color:#666; font-size:0.9rem; }
        .form-control { border:2px solid #e8f4fd; border-radius:10px; padding:12px 16px; }
        .form-control:focus { border-color:#0077b6; box-shadow:none; }
        .btn-login { background:linear-gradient(135deg,#0077b6,#00b4d8); border:none; border-radius:50px; width:100%; padding:13px; font-weight:700; font-size:1rem; }
        .btn-login:hover { transform:translateY(-2px); box-shadow:0 8px 20px rgba(0,119,182,0.35); }
    </style>
</head>
<body>
<form id="frmLogin" runat="server">
    <div class="login-card">
        <div class="login-brand">
            <i class="fas fa-umbrella-beach"></i>
            <h3>Ba Động Admin</h3>
            <p>Hệ thống quản trị du lịch Ba Động</p>
        </div>
        <asp:Label ID="lblMsg" runat="server" CssClass="d-block mb-3 p-3 rounded-3 text-danger" Visible="false"
                   style="background:#fff5f5;border:1px solid #ffcccc;" />
        <div class="mb-3">
            <label class="form-label fw-700">Tên đăng nhập</label>
            <div class="input-group">
                <span class="input-group-text" style="border:2px solid #e8f4fd;border-right:none;border-radius:10px 0 0 10px;background:#f8fbff;">
                    <i class="fas fa-user text-muted"></i>
                </span>
                <asp:TextBox ID="txtUser" runat="server" CssClass="form-control" placeholder="admin"
                             style="border-left:none;border-radius:0 10px 10px 0;" />
            </div>
        </div>
        <div class="mb-4">
            <label class="form-label fw-700">Mật khẩu</label>
            <div class="input-group">
                <span class="input-group-text" style="border:2px solid #e8f4fd;border-right:none;border-radius:10px 0 0 10px;background:#f8fbff;">
                    <i class="fas fa-lock text-muted"></i>
                </span>
                <asp:TextBox ID="txtPass" runat="server" CssClass="form-control" TextMode="Password" placeholder="••••••••"
                             style="border-left:none;border-radius:0 10px 10px 0;" />
            </div>
        </div>
        <asp:Button ID="btnLogin" runat="server" Text="Đăng Nhập" CssClass="btn btn-primary btn-login text-white" OnClick="btnLogin_Click" />
        <div class="text-center mt-4">
            <a href="../Default.aspx" class="text-muted small"><i class="fas fa-arrow-left me-1"></i>Về trang chủ</a>
        </div>
    </div>
    <script src="https://cdn.jsdelivr.net/npm/bootstrap@5.3.0/dist/js/bootstrap.bundle.min.js"></script>
</form>
</body>
</html>
