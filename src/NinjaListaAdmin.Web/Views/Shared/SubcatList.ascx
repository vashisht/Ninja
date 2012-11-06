<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<NinjaListaAdmin.Web.Views.Models.SubCategoryModel>" %>
 <% string strtable = ViewData["load"].ToString(); %>
                  

              
<div id="tablediv" style="width: 905px; height: auto; float: left; margin-left: 10px;
        margin-top: 5px; margin-bottom: 30px; padding-left: 10px; color: Black; padding-top: 10px;">
        <div id="resultStatus">
        </div>
        <input id="load" type="hidden" value="<%= strtable%>" />
        <div style="clear: both;">
        </div>
        <%if (Model != null && Model.subcats != null && Model.subcats.Count > 0) %>
            <% { %>
        <table cellpadding="0" cellspacing="0" id="tbllist" style="width: 99%; float: left;">
            <thead class="Thead">
                <tr>
                    <th style="width: 150px; border: 1px solid #e2cfb3; text-align: center; color: Black;">
                        Category
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
                <%foreach (var m in Model.subcats) %>
                <% { %>
                <tr style="height: 40px; background-color: #f9f9f9;">
                    <td style="border: 1px solid #e9e9e9; vertical-align: middle; text-align: center;
                        color: Black;">
                        <%=m.SubCategoryName%>
                    </td>
                    <td style="border: 1px solid #e9e9e9; vertical-align: middle; text-align: center;
                        color: Black;">
                        <%if (m.Active == true)  %>
                        <%{ %>
                        <a class="isactive" cid="true" id="<%= m.SubCategoryId %>" title="click to deactivate" href="">
                            <span id="sp<%=m.SubCategoryId %>">Active</span></a>
                        <%} %>
                        <% else%>
                        <%{ %>
                        <a class="isactive" cid="false" id="<%= m.SubCategoryId %>" title="click to activate" href=""><span
                            id="sp<%=m.SubCategoryId %>">Inactive</span></a>
                        <%} %>
                    </td>
                    <td style="border: 1px solid #e9e9e9; vertical-align: middle; text-align: center;">
                        <%=Html.ActionLink("Edit", "EditSubCategory", "Home", new { id = m.SubCategoryId }, new { @class = "button" })%>
                    </td>
                </tr>
                <%} %>
            </tbody>
            
           
        </table>
        <%} %>

      
    </div>
    <script type="text/javascript">
        $(function () {


               $('#tbllist').dataTable({
                    "bJQueryUI": true,
                    "sPaginationType": "full_numbers"

                });


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

                

                if (confirm("Do you want to change the status of this Sub Category?")) {
                    $("#resultStatus").html("Please wait...").show();
                    $("#tablediv").block();
                    $.post("/Home/ChangeSubCategoryStatus", { 'SubCategoryId': id, 'Value': v }, function (data) {
                        if (data.Success) {
                            //                            window.location = "/Home/ManageSubCategories";
                            
                            $('#sp' + id).html('Active');
                            $this.attr({ "cid": "true", "title": "click to Inactivate this Sub Category" });

                            if (v == true) {
                                $('#sp' + id).html('Inactive');
                                $this.attr({ "cid": "false", "title": "click to activate this Sub Category" });
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

    

