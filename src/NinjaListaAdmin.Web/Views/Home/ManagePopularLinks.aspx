<%@ Page Language="C#" MasterPageFile="~/Views/Shared/Admin.Master" Inherits="System.Web.Mvc.ViewPage<NinjaListaAdmin.Web.Views.Models.PopularLinkModel>" %>

<%@ Import Namespace="NinjaListaAdmin" %>
<asp:Content ID="indexContent" ContentPlaceHolderID="MainContentPlaceHolder" runat="server">
<div style="padding-left:25px; padding-bottom:2px;"><%=Html.ActionLink("Add Popular Link", "NewPopularLink", "Home",  new { @class = "button" })%></div>
    <div id="tablediv" style="width: 905px; height: auto; float: left; margin-left: 10px;
        margin-top: 5px; margin-bottom: 30px; padding-left: 10px; color: Black; padding-top: 10px;">
        <div id="resultStatus">
        </div>
        <div style="clear: both;">
        </div>
        <%if (Model != null && Model.plinks != null && Model.plinks.Count > 0) %>
            <% { %>
        <table cellpadding="0" cellspacing="0" id="tbllist" style="width: 99%; float: left;">
            <thead class="Thead">
                <tr>
                    <th style="width: 150px; border: 1px solid #e2cfb3; text-align: center; color: Black;">
                        Title
                    </th>
                     <th style="width: 150px; border: 1px solid #e2cfb3; text-align: center; color: Black;">
                        Link
                    </th>
                    <th style="width: 80px; border: 1px solid #e2cfb3; text-align: center; color: Black;">
                        Active
                    </th>
                    <th style="width: 80px; border: 1px solid #e2cfb3; text-align: center; color: Black;">
                        Edit
                    </th>
                </tr>
            </thead>
            
            <tbody>
                <%foreach (var m in Model.plinks) %>
                <% { %>
                <tr style="height: 40px; background-color: #f9f9f9;">
                    <td style="border: 1px solid #e9e9e9; vertical-align: middle; text-align: center;
                        color: Black;">
                        <%=m.Title   %>
                    </td>

                     <td style="border: 1px solid #e9e9e9; vertical-align: middle; text-align: center;
                        color: Black;">
                        <%=m.Link    %>
                    </td>
                    <td style="border: 1px solid #e9e9e9; vertical-align: middle; text-align: center;
                        color: Black;">
                        <%if (m.Active == true)  %>
                        <%{ %>
                        <a class="isactive" cid="true" id="<%= m.PopularLinkId %>" title="click to deactivate" href="">
                            <span id="sp<%=m.PopularLinkId %>">Active</span></a>
                        <%} %>
                        <% else%>
                        <%{ %>
                        <a class="isactive" cid="false" id="<%= m.PopularLinkId %>" title="click to activate" href=""><span
                            id="sp<%=m.PopularLinkId %>">Inactive</span></a>
                        <%} %>
                    </td>
                    <td style="border: 1px solid #e9e9e9; vertical-align: middle; text-align: center;">
                        <%=Html.ActionLink("Edit", "EditPopularLink", "Home", new { id = m.PopularLinkId  }, new { @class = "button" })%>
                    </td>
                </tr>
                <%} %>
            </tbody>
            
           
        </table>
        <%} %>
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

                if (confirm("Do you want to change the status of this Link?")) {
                    $("#resultStatus").html("Please wait...").show();
                    $("#tablediv").block();
                    $.post("/Home/ChangeLinkStatus", { 'LinkId': id, 'Value': v }, function (data) {
                        if (data.Success) {
                            window.location = "/Home/ManageCategories";
                            if (!v) {

                                $('#sp' + id).html('Active');
                                $this.attr({ "cid": "true", "title": "click to Inactivate this Link" });
                            }
                            else {
                                $('#sp' + id).html('Inactive');
                                $this.attr({ "cid": "false", "title": "click to activate this Link" });
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
