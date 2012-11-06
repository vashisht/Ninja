<%@ Page Language="C#" MasterPageFile="~/Views/Shared/Admin.Master" Inherits="System.Web.Mvc.ViewPage<NinjaListaAdmin.Web.Views.Models.AdvertListModel>" %>

<%@ Import Namespace="NinjaListaAdmin" %>
<asp:Content ID="indexContent" ContentPlaceHolderID="MainContentPlaceHolder" runat="server">
<%--<div style="padding-left:25px; padding-bottom:2px;"><%=Html.ActionLink("Add Add", "NewAdd", "Home",  new { @class = "button" })%></div>--%>
    <div id="tablediv" style="width: 905px; height: auto; float: left; margin-left: 10px;
        margin-top: 5px; margin-bottom: 30px; padding-left: 10px; color: Black; padding-top: 10px;">
        <div id="resultStatus">
        </div>
        <div style="clear: both;">
        </div>
        <table cellpadding="0" cellspacing="0" id="tbllist" style="width: 99%; float: left;">
            <thead class="Thead">
                <tr>
                    <th style="width: 150px; border: 1px solid #e2cfb3; text-align: center; color: Black;">
                        Category
                    </th>
                     <th style="width: 200px; border: 1px solid #e2cfb3; text-align: center; color: Black;">
                        Sub Category
                    </th>
                     <th style="width: 150px; border: 1px solid #e2cfb3; text-align: center; color: Black;">
                        Title
                    </th>
                      <th style="width: 150px; border: 1px solid #e2cfb3; text-align: center; color: Black;">
                        Location
                    </th>
                    <th style="width: 60px; border: 1px solid #e2cfb3; text-align: center; color: Black;">
                        Active
                    </th>
                   <%-- <th style="width: 60px; border: 1px solid #e2cfb3; text-align: center; color: Black;">
                        Edit
                    </th>--%>
                </tr>
            </thead>
            <%if (Model != null && Model.adverts != null && Model.adverts.Count > 0) %>
            <% { %>
            <tbody>
                <%foreach (var m in Model.adverts) %>
                <% { %>
                <tr style="height: 40px; background-color: #f9f9f9;">
                    <td style="border: 1px solid #e9e9e9; vertical-align: middle; text-align: center;
                        color: Black;">
                        <%=m.Category   %>
                    </td>
                     <td style="border: 1px solid #e9e9e9; vertical-align: middle; text-align: center;
                        color: Black;">
                        <%=m.SubCategory    %>
                    </td>
                    <td style="border: 1px solid #e9e9e9; vertical-align: middle; text-align: center;
                        color: Black;">
                        <%=m.Title     %>
                    </td>
                     <td style="border: 1px solid #e9e9e9; vertical-align: middle; text-align: center;
                        color: Black;">
                        <%=m.Location  %>
                    </td>
                    <td style="border: 1px solid #e9e9e9; vertical-align: middle; text-align: center;
                        color: Black;">
                        <%if (m.Active == true)  %>
                        <%{ %>
                        <a class="isactive" cid="true" id="<%= m.AdId %>" title="click to deactivate" href="">
                            <span id="sp<%=m.AdId %>">Active</span></a>
                        <%} %>
                        <% else%>
                        <%{ %>
                        <a class="isactive" cid="false" id="<%= m.AdId %>" title="click to activate" href=""><span
                            id="sp<%=m.AdId %>">Inactive</span></a>
                        <%} %>
                    </td>
                  <%--  <td style="border: 1px solid #e9e9e9; vertical-align: middle; text-align: center;">
                        <%=Html.ActionLink("Edit", "EditAdd", "Home", new { id = m.AdId  }, new { @class = "button" })%>
                    </td>--%>
                </tr>
                <%} %>
            </tbody>
            
            
        </table>
        <% }%>
    </div>
    <script type="text/javascript">
        $(function () {



            var count = $('#tbllist tr').length;
            if (count > 1) {
                ////            $('#table1').dataTable();

                oTable = $('#tbllist').dataTable({
                    "bJQueryUI": true,
                    "sPaginationType": "full_numbers"

                });
            }


            $(".isactive").click(function () {
                var $this = $(this);
                var path = $(this).attr("cid");
                var v = true;
                if (path == 'true') {
                    v = false;
                }
                else {
                    v = true;
                }
                var id = $(this).attr("id");

                if (confirm("Do you want to change the status of this Advertisement?")) {
                    $("#resultStatus").html("Please wait...").show();
                    $("#tablediv").block();
                    $.post("/Home/ChangeAdStatus", { 'Adid': id, 'Value': v }, function (data) {
                        if (data.Success) {
                            window.location = '/Home/ManageAds';

                            if (!v) {

                                $('#sp' + id).html('Active');
                                $this.attr({ "cid": "true", "title": "click to Inactivate this Advertisement" });
                            }
                            else {
                                $('#sp' + id).html('Inactive');
                                $this.attr({ "cid": "false", "title": "click to activate this Advertisement" });
                            }
                        }
                        else {
                            $("#resultStatus").addClass("RedClass");
                        }
                        $("#tablediv").unblock();
                        $("#resultStatus").html(data.Message);
                        setTimeout("fadingOut()", 3000);
                    });
                }
            });

        });
        function fadingOut() {
            $("#resultStatus").fadeOut("500");
        }
    </script>
    
</asp:Content>
