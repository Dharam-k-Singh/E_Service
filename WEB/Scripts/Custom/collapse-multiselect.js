const collapseMSHtml = "" +
    "<div id=\"_collapse_ms\" class=\"collapse-ms form-control p-0\">" +
    "    <button id=\"_collapse_ms_toggle\" class=\"collapse-ms-toggle btn w-100 text-start text-truncate\" type=\"button\" data-bs-toggle=\"collapse\" data-bs-target=\"#_collapse_ms_menu\">Test Placeholder Text</button>" +
    "    <div id=\"_collapse_ms_menu\" class=\"collapse border-top collapse-ms-menu collapsible-no-close\">" +
    "        <div class=\"collapsible-no-close m-2 pb-2 border-bottom\">" +
    "            <div class=\"collapsible-no-close\">" +
    "                <input id=\"_collapse_ms_search\" class=\"form-control form-control-sm collapse-ms-search validation-ignore\" placeholder=\"Search...\" type=\"text\" />" +
    "            </div>" +
    "            <div class=\"mt-2 collapsible-no-close\">" +
    "                <button id=\"_collapse_ms_sa\" type=\"button\" class=\"btn btn-outline-primary btn-sm me-2\">Select All</button>" +
    "                <button id=\"_collapse_ms_dsa\" type=\"button\" class=\"btn btn-outline-primary btn-sm me-2\">De-Select All</button>" +
    "                <span id=\"_collapse_ms_psat\" class=\"collapsible-no-close\">Please select all applicable</span>" +
    "            </div>" +
    "        </div>" +
    "        <div id=\"_collapse_ms_item\" class=\"collapse-ms-item collapsible-no-close m-1 p-2\"><input class=\"form-check-input collapse-ms-checkbox\" type=\"checkbox\" disabled> <i class=\"collapse-ms-iconcheck fa fa-check float-end collapsible-no-close\"></i></div>" +
    "    </div>" +
    "</div>" +
    "";

$.fn.extend({
    collapse_multiselect: function (options) {
        return this.each(function () {

            let settings = $.extend({
                selectText: "-- Select --",
                disableSearch: false,
                disableSelectAll: false,
                disableDeSelectAll: false,
                manualSelectAll: false,
                manualSelectAllIndex: 0,
            }, options);

            if (settings.enableSelectAll && settings.manualSelectAll) {
                console.error("Collapse Multi-Select: Cannot have both Select All and Manual Select All Enabled");
                return;
            }

            let element = $(this);

            let id = element.prop("id");
            let type = element.prop("type");
            let isMultiple = element.prop("multiple");
            let originalName = element.prop("name");

            if (type != "select-one" && type != "select-multiple") {
                console.error("Collapse Multi-Select: Cannot be applied on anything else other than <select> inputs");
                return;
            }

            element.css("display", "none");

            let collapseMS = $(collapseMSHtml);
            collapseMS.prop("id", id + collapseMS.prop("id"));
            $("#" + collapseMS.prop("id")).remove();

            let collapseMSMenu = collapseMS.find("#_collapse_ms_menu");
            collapseMSMenu.prop("id", id + collapseMSMenu.prop("id"));

            let collapseMSToggle = collapseMS.find("#_collapse_ms_toggle");
            collapseMSToggle.prop("id", id + collapseMSToggle.prop("id"));
            collapseMSToggle.attr("data-bs-target", "#" + collapseMSMenu.prop("id"))

            let collapseMSSearch = collapseMSMenu.find("#_collapse_ms_search");
            collapseMSSearch.prop("id", id + collapseMSSearch.prop("id"));

            let collapseMSSelectAll = collapseMSMenu.find("#_collapse_ms_sa");
            collapseMSSelectAll.prop("id", id + collapseMSSelectAll.prop("id"));

            let collapseMSDeSelectAll = collapseMSMenu.find("#_collapse_ms_dsa");
            collapseMSDeSelectAll.prop("id", id + collapseMSDeSelectAll.prop("id"));

            let collapseMSPsat = collapseMSMenu.find("#_collapse_ms_psat");
            collapseMSPsat.prop("id", id + collapseMSPsat.prop("id"));

            let collapseMSItem = collapseMSMenu.find("#_collapse_ms_item");
            //collapseMSItem.prop("id", id + collapseMSItem.prop("id"));
            collapseMSItem.removeProp("id");
            collapseMSItem.remove();

            collapseMSToggle.on("click.cms", function () {
                collapseMSSearch.val(null).trigger("input.cms");
                $(".collapse-ms-menu").collapse("hide");
            });

            let selectedValues = [];

            if (!isMultiple) {
                collapseMSPsat.remove();
                selectedValues.push(element.val());
            }
            else selectedValues = element.val();

            if (!selectedValues || selectedValues == "") selectedValues = [];

            let getCollapseMSItems = function () {
                return collapseMSMenu.find(".collapse-ms-item");
            };

            let updateCollapseMS = function (doChange = false) {
                let html = "";
                let htmlChanged = false;
                getCollapseMSItems().each(function () {
                    let item = $(this);
                    let value = item.data("dd-value");
                    let text = item.data("dd-text");

                    if (selectedValues.includes(value)) {
                        item.addClass("active").find("input[type='checkbox']").prop("checked", true);
                        html += text + ", ";
                        htmlChanged = true;
                    }
                    else {
                        item.removeClass("active").find("input[type='checkbox']").prop("checked", false);
                    }
                });

                if (htmlChanged) html = html.substring(0, html.length - 2);
                else html = settings.selectText;

                collapseMSToggle.html(html);

                element.val(selectedValues);

                if (doChange) {
                    element.change();
                }

                if (!isMultiple) {
                    collapseMSSearch.val(null).trigger("input.cms");
                    $(".collapse-ms-menu").collapse("hide");
                }
            }

            let changeCollapseMSItems = function (select, value = undefined) {
                if (select) {
                    selectedValues = [];
                    getCollapseMSItems().each(function (e) {
                        let item = $(this);
                        let value = item.data("dd-value");

                        selectedValues.push(value);
                    });

                    if (value && value != "") {
                        let index = selectedValues.indexOf(value);
                        if (index >= 0) selectedValues.splice(index, 1);
                    }
                }
                else {
                    selectedValues = [];
                    if (value && value != "") selectedValues.push(value);
                }

                updateCollapseMS(true);
            }

            if (settings.disableSearch) {
                collapseMSSearch.remove();
            }
            else {
                collapseMSSearch.on("input.cms", function (e) {
                    let searchText = this.value;

                    getCollapseMSItems().each(function () {
                        if ($(this).text().search(new RegExp(searchText, "i")) < 0) {
                            $(this).hide();
                        }
                        else {
                            $(this).show();
                        }
                    });
                });
            }

            if (settings.disableSelectAll || !isMultiple || settings.manualSelectAll) {
                collapseMSSelectAll.remove();
            }
            else {
                collapseMSSelectAll.on("click.cms", function (e) {
                    e.stopPropagation();

                    changeCollapseMSItems(true);
                });
            }

            if (settings.disableDeSelectAll) {
                collapseMSDeSelectAll.remove();
            }
            else {
                if (!isMultiple) collapseMSDeSelectAll.html("De-Select");

                collapseMSDeSelectAll.on("click.cms", function (e) {
                    e.stopPropagation();

                    changeCollapseMSItems(false);
                });
            }

            let optionElems = element.find("option");
            alreadySelectedValues = element.val();
            optionElems.each(function (index) {
                let item = collapseMSItem.clone(true);
                let value = this.value;

                if (value) {
                    item.data("dd-value", value);
                    item.data("dd-text", this.innerHTML);

                    item.find("input").after(this.innerHTML);

                    if (!isMultiple) item.addClass("collapse-ms-item-single");

                    item.on("click.cmdd", function (e) {

                        e.stopPropagation();

                        let itemVal = $(this).data("dd-value");
                        let itemText = $(this).data("dd-text");

                        if (!isMultiple) {
                            changeCollapseMSItems(false, itemVal);
                            return;
                        }

                        if (settings.manualSelectAll) {
                            if (index - 1 == settings.manualSelectAllIndex) {
                                changeCollapseMSItems(false, itemVal);
                                return;
                            } else {
                                let item = $(getCollapseMSItems()[settings.manualSelectAllIndex]);
                                let value = item.data("dd-value");

                                let itemIndex = selectedValues.indexOf(value);
                                if (itemIndex >= 0) selectedValues.splice(itemIndex, 1);
                            }
                        }

                        if (!selectedValues.includes(itemVal)) selectedValues.push(itemVal);
                        else {
                            let itemIndex = selectedValues.indexOf(value);
                            if (itemIndex >= 0) selectedValues.splice(itemIndex, 1);
                        }
                        updateCollapseMS(true);
                    });

                    collapseMSMenu.append(item);
                }
            });

            updateCollapseMS();
            element.after(collapseMS);
        });
    }
});