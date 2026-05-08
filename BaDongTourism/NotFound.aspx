<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Site.Master" Title="404 - Không tìm thấy trang" %>

<asp:Content ID="MainContent" ContentPlaceHolderID="MainContent" runat="server">
<div style="min-height:60vh;display:flex;align-items:center;justify-content:center;text-align:center;padding:60px 20px;">
    <div>
        <div style="font-size:8rem;font-weight:800;background:linear-gradient(135deg,#0077b6,#00b4d8);
                    -webkit-background-clip:text;-webkit-text-fill-color:transparent;line-height:1;">
            404
        </div>
        <h2 class="fw-bold mt-3 mb-2">Trang Không Tìm Thấy</h2>
        <p class="text-muted mb-4">Trang bạn yêu cầu không tồn tại hoặc đã bị xóa.<br/>
           Hãy quay về trang chủ để tiếp tục khám phá Ba Động.</p>
        <div class="d-flex gap-3 justify-content-center flex-wrap">
            <a href="Default.aspx" class="btn btn-primary">
                <i class="fas fa-home me-2"></i>Về Trang Chủ
            </a>
            <a href="LienHe.aspx" class="btn btn-outline-primary">
                <i class="fas fa-envelope me-2"></i>Liên Hệ
            </a>
        </div>
    </div>
</div>
</asp:Content>
