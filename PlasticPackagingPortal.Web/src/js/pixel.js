
import * as bootstrap from "bootstrap";
import Vivus from "vivus";
import Headroom from "headroom.js";
import noUiSlider from "nouislider";
import SmoothScroll from "smooth-scroll";

import Choices from "choices.js"
import Datepicker from 'vanillajs-datepicker/Datepicker';
import { parse, format } from "date-fns"; 

import "datatables.net";
import "datatables.net-bs5";
import 'datatables.net-bs5/css/dataTables.bootstrap5.css';
import 'datatables.net-buttons';
import 'datatables.net-buttons-bs5';
import 'datatables.net-buttons-bs5/css/buttons.bootstrap5.css';
import 'jquery-validation';
import Swal from 'sweetalert2'


const d = document;
d.addEventListener("DOMContentLoaded", function (event) {

    // options
    const breakpoints = {
        sm: 540,
        md: 720,
        lg: 960,
        xl: 1140
    };

    if(document.getElementById('navbar_global')) {
        document.getElementById('navbar_global').addEventListener('shown.bs.collapse', function() {
            document.getElementsByTagName('body')[0].classList.add('overflow-hidden');
        });
    
        document.getElementById('navbar_global').addEventListener('hidden.bs.collapse', function() {
            document.getElementsByTagName('body')[0].classList.remove('overflow-hidden');
        });
    }

    var preloader = d.querySelector('.preloader');
    if (preloader) {

        const animations = ['oneByOne', 'delayed', 'sync', 'scenario'];

        new Vivus('loader-logo', { duration: 80, type: 'oneByOne' }, function () { });

        setTimeout(function () {
            preloader.classList.add('show');
        }, 1500);
    }

    if (d.querySelector('.headroom')) {
        var headroom = new Headroom(document.querySelector("#navbar-main"), {
            offset: 0,
            tolerance: {
                up: 0,
                down: 0
            },
        });
        headroom.init();
    }

    // dropdowns to show on hover when desktop
    if (d.body.clientWidth > breakpoints.lg) {
        var dropdownElementList = [].slice.call(document.querySelectorAll('.navbar .dropdown-toggle'))
        dropdownElementList.map(function (dropdownToggleEl) {
            var dropdown = new bootstrap.Dropdown(dropdownToggleEl);
            var dropdownMenu = d.querySelector('.dropdown-menu[aria-labelledby="' + dropdownToggleEl.getAttribute('id') + '"]');

            dropdownToggleEl.addEventListener('mouseover', function () {
                dropdown.show();
            });
            dropdownToggleEl.addEventListener('mouseout', function () {
                dropdown.hide();
            });

            dropdownMenu.addEventListener('mouseover', function () {
                dropdown.show();
            });
            dropdownMenu.addEventListener('mouseout', function () {
                dropdown.hide();
            });

        });
    }

    [].slice.call(d.querySelectorAll('[data-background]')).map(function (el) {
        el.style.background = 'url(' + el.getAttribute('data-background') + ')';
    });

    [].slice.call(d.querySelectorAll('[data-background-color]')).map(function (el) {
        el.style.background = 'url(' + el.getAttribute('data-background-color') + ')';
    });

    [].slice.call(d.querySelectorAll('[data-color]')).map(function (el) {
        el.style.color = 'url(' + el.getAttribute('data-color') + ')';
    });

    // Tooltips
    var tooltipTriggerList = [].slice.call(document.querySelectorAll('[data-bs-toggle="tooltip"]'))
    var tooltipList = tooltipTriggerList.map(function (tooltipTriggerEl) {
        return new bootstrap.Tooltip(tooltipTriggerEl)
    })

    // Popovers
    var popoverTriggerList = [].slice.call(document.querySelectorAll('[data-bs-toggle="popover"]'))
    var popoverList = popoverTriggerList.map(function (popoverTriggerEl) {
        return new bootstrap.Popover(popoverTriggerEl)
    })

    // Datepicker
    var datepickers = [].slice.call(document.querySelectorAll('[data-datepicker]'))
    var datepickersList = datepickers.map(function (el) {
        return new Datepicker(el, {
            buttonClass: 'btn'
        });
    })

    // Toasts
    var toastElList = [].slice.call(document.querySelectorAll('.toast'))
    var toastList = toastElList.map(function (toastEl) {
        return new bootstrap.Toast(toastEl)
    })

    if (d.querySelector('.input-slider-container')) {
        [].slice.call(d.querySelectorAll('.input-slider-container')).map(function (el) {
            var slider = el.querySelector(':scope .input-slider');
            var sliderId = slider.getAttribute('id');
            var minValue = slider.getAttribute('data-range-value-min');
            var maxValue = slider.getAttribute('data-range-value-max');

            var sliderValue = el.querySelector(':scope .range-slider-value');
            var sliderValueId = sliderValue.getAttribute('id');
            var startValue = sliderValue.getAttribute('data-range-value-low');

            var c = document.getElementById(sliderId),
                id = document.getElementById(sliderValueId);

            noUiSlider.create(c, {
                start: [parseInt(startValue)],
                connect: [true, false],
                //step: 1000,
                range: {
                    'min': [parseInt(minValue)],
                    'max': [parseInt(maxValue)]
                }
            });
        });
    }

    if (d.getElementById('input-slider-range')) {
        var c = d.getElementById("input-slider-range"),
            low = d.getElementById("input-slider-range-value-low"),
            e = d.getElementById("input-slider-range-value-high"),
            f = [d, e];

        noUiSlider.create(c, {
            start: [parseInt(low.getAttribute('data-range-value-low')), parseInt(e.getAttribute('data-range-value-high'))],
            connect: !0,
            tooltips: true,
            range: {
                min: parseInt(c.getAttribute('data-range-value-min')),
                max: parseInt(c.getAttribute('data-range-value-max'))
            }
        }), c.noUiSlider.on("update", function (a, b) {
            f[b].textContent = a[b]
        });
    }

    if (d.getElementById('loadOnClick')) {
        d.getElementById('loadOnClick').addEventListener('click', function () {
            var button = this;
            var loadContent = d.getElementById('extraContent');
            var allLoaded = d.getElementById('allLoadedText');

            button.classList.add('btn-loading');
            button.setAttribute('disabled', 'true');

            setTimeout(function () {
                loadContent.style.display = 'block';
                button.style.display = 'none';
                allLoaded.style.display = 'block';
            }, 1500);
        });
    }

    var scroll = new SmoothScroll('a[href*="#"]', {
        speed: 500,
        speedAsDuration: true
    });

    // update target element content to match number of characters
    var dataBindCharacters = [].slice.call(document.querySelectorAll('[data-bind-characters-target]'))
    dataBindCharacters.map(function (el) {
        var text = d.querySelector(el.getAttribute('data-bind-characters-target'));
        var maxCharacters = parseInt(el.getAttribute('maxlength'));
        text.textContent = maxCharacters;

        el.addEventListener('keyup', function (event) {
            var string = this.value;
            var characters = string.length;
            var charactersRemaining = maxCharacters - characters;
            text.textContent = charactersRemaining;
        });

        el.addEventListener('change', function (event) {
            var string = this.value;
            var characters = string.length;
            var charactersRemaining = maxCharacters - characters;
            text.textContent = charactersRemaining;
        });

    });

    // CountUP
    var counters = [].slice.call(document.querySelectorAll('.counter'));
    counters.map(function (el) {
        var numAnim = new countUp.CountUp(el, el.textContent);
        numAnim.start();
    });

    if (d.querySelector('.current-year')) {
        d.querySelector('.current-year').textContent = new Date().getFullYear();
    }

    packagesTable();
});

async function finaliseDatatableButton(e, dt, node, config)
{
    const data = dt.rows().data().filter(x => x.selected).map(x => x.id).toArray();
    if(data.length === 0) return;

    const url = dt.table().node().dataset.finalise;
    
    try {
        
        Swal.fire({
            title: 'Finalising items',
            icon: 'info',
            showConfirmButton: false,
            didOpen: () => {
                Swal.showLoading();
            },
        });

        const request = await fetch(url, {
                    method: 'post',
                    headers: {
                        'Accept': 'application/json',
                        'Content-Type': 'application/json'
                    },
                    body: JSON.stringify(data)
                });

        const response = await request.json();

        if(response && response.redirect)
            window.location.href = response.redirect;

    } catch (e) {
        Swal.fire({
            title: 'Failed to update item',
            text: e.message,
            icon: 'error'
        });
    }

}

async function deleteDatatableButton(e, dt, node, config)
{
    const data = dt.rows().data().filter(x => x.selected).map(x => x.id).toArray();
    if(data.length === 0) return;

    const url = dt.table().node().dataset.delete;
    
    try {
        
        Swal.fire({
            title: 'Deleting items',
            icon: 'info',
            showConfirmButton: false,
            didOpen: () => {
                Swal.showLoading();
            },
        });

        const request = await fetch(url, {
                    method: 'delete',
                    headers: {
                        'Accept': 'application/json',
                        'Content-Type': 'application/json'
                    },
                    body: JSON.stringify(data)
                });

        const response = await request.json();

        dt.ajax.reload();
        Swal.close();
            

    } catch (e) {
        Swal.fire({
            title: 'Failed to delete items',
            text: e.message,
            icon: 'error'
        });
    }

}

async function getStagingTableButtons() {
    return [
        {
            text: 'Finalise',
            className: 'btn-sm btn-success text-white',
            action: finaliseDatatableButton
        },
        {
            text: 'Delete',
            className: 'btn-sm btn-danger',
            action: deleteDatatableButton
        }
    ]
}

async function getValidatedTableButtons() {
    return [
        {
            text: 'Delete',
            className: 'btn-sm btn-danger',
            action: deleteDatatableButton
        }
    ]
}

function getColumns() {
    return [   
            { 
                name: 'select',
                data: null,
                searchable: false,
                orderable: false,
                render: function (data, type, row) {
                    const checked = row.selected ? `checked="checked"` : '';
                    return `
                        <div class="form-check">
                            <input class="form-check-input select-row" type="checkbox" id="rowCheckbox-${row.id}" ${checked}>
                            <label class="visually-hidden" for="rowCheckbox-${row.id}">Select row</label>
                        </div>`;
                }
            },
            { data: 'identifier', name: 'identifier' },
            { data: 'name', name: 'name' },
            { data: 'description', name: 'description' },
            { data: 'lowCode', name: 'lowCode' },
            { 
                name: 'updateDate',
                data: 'updateDate', 
                render: function (data, type, row) {
                    try {
                        const date = parse(data, 'dd/MM/yyyy', new Date());
                        if(type === 'display')
                            return data;
                        else
                            return format(date, 'T');
                    } catch (e) {
                        console.warn('Failed to prase ' + data + 'as date.');
                        return null;
                    }
                }
            },
            { 
                name: 'status',
                data: null, 
                render: function (data, type, row) {
                    if(type === 'display')
                    {
                        const badge = row.errors ? `<span class="badge bg-danger">Validation errors</span>` : `<span class="badge bg-success">Validation passed</span>`;
                        return `${badge}`;
                    }
                    else
                        return row.errors ? 'errors' : null;
                }
            },
            {
                name: 'actions',
                data: null,
                searchable: false,
                orderable: false,
                render: function (data, type, row) {
                    return `
                        <button class="btn btn-sm btn-secondary animate-up-2" data-bs-toggle="modal" data-bs-target="#editRowModal" data-id="${row.id}" type="button">Edit</button>
                    `;
                }
            }
        ];
}

function initialiseDatepickers(selector = 'input.datepicker'){

    const datepickers = [];

    [...document.querySelectorAll(selector)].forEach((input) => {
        datepickers.push({
            id: input.id,
            instance: new Datepicker(input, {
                format: 'dd/mm/yyyy'
            })
        });
    });

    return datepickers;
}

function toPascalCase (str){
    return str.charAt(0).toUpperCase() + str.slice(1);
}

async function editStagingItemForm(dt, modal){
    const form = document.getElementById('editRowForm');

    const validator = $(form).validate({
        rules: {
            Name: {
                required: true
            },
            Height: {
                number: true
            },
            HeightDate: {
                date: true
            },
            Width: {
                number: true
            },
            WidthDate: {
                date: true
            },
            Depth: {
                number: true
            },
            DepthDate: {
                date: true
            },
            Volume: {
                number: true
            },
            VolumeDate: {
                date: true
            },
            Weight: {
                number: true
            },
            WeightDate: {
                date: true
            },
            PartOfMultipack: {
                number: true,
                min: 0,
                max: 1,
                step: 1
            },
            UpdateDate: {
                date: true
            },
            ReleaseDate: {
                date: true
            },
            DiscontinueDate: {
                date: true
            },
        },
        messages: {
            
        },
        errorClass: 'is-invalid',
        validClass: 'is-valid',
        errorElement: "div",
        errorPlacement: function ( error, element ) {
            error.addClass( "invalid-feedback" );
            error.insertAfter( element );
        },
        highlight: function(element) {
            $(element).removeClass('is-valid').addClass('is-invalid');
        },
        unhighlight: function(element) {
            $(element).removeClass('is-invalid').addClass('is-valid');
        },
        submitHandler: async function (form, e) {
            e.preventDefault();

            const data = new FormData(form);
            const url = form.getAttribute('action');

            try {
                const request = await fetch(url, {
                    method: 'post',
                    body: data
                });

                const response = await request.json();

                const row = dt.row('#' + response.id);
                row.data(response);
                row.invalidate();
                modal.hide();

                Swal.fire({
                    title: 'Saved successfully',
                    toast: true,
                    icon: 'success',
                    timer: 4000,
                    position: 'bottom-end',
                    timerProgressBar: true,
                    showConfirmButton: false
                })
                
            } catch (e) {
                Swal.fire({
                    title: 'Failed to update item',
                    icon: 'error'
                });
            }
          

            return false;
        }
    });
}

async function packagesTable() {
    const tableEl = document.getElementById("packagesTable");    
    
    if(document.getElementById("packagesTable"))
    {
        const datepickers = initialiseDatepickers();

        const buttons = tableEl.dataset.type === 'staging' ? await getStagingTableButtons() : await getValidatedTableButtons();

        const columns = getColumns();
        
        const dt = $(tableEl).DataTable({
            dom: `<"row"<"col-12 col-lg-6"<"d-flex align-items-center"B>><"col-12 col-lg-6"<"d-flex justify-content-end align-items-center"f>>t<"my-3 small"i><"row"<"col-12 col-lg-6"<"d-flex align-items-center"l>><"col-12 col-lg-6"<"d-flex justify-content-end align-items-center"p>>>`,
            
            buttons: buttons,
            language: {
                lengthMenu: `  <div class="d-flex align-items-center">
                                    <span class="me-1">Show</span>
                                        <select class="form-select form-select-sm fmw-70">
                                            <option value="10">10</option>
                                            <option value="25">25</option>
                                            <option value="50">50</option>
                                            <option value="100">100</option>
                                            <option value="-1">All</option>
                                        </select>
                                    <span class="ms-1">items</span>
                                </div>`
                ,
                search: '',
                searchPlaceholder: 'Search items...',
                infoEmpty: "No items",
                info: "Showing _START_ to _END_ of _TOTAL_ items",
                infoFiltered: "(filtered from _MAX_ total items)",
                emptyTable: `<div class="d-flex justify-content-center">No items</span>`,
            },
            pagingType: 'numbers',
            ajax: {
                url: tableEl.dataset.get,
                type: 'post'
            },
            columns: tableEl.dataset.type === 'validated' ? columns.filter((col) => { return col.name !== 'status'}).filter((col) => { return col.name !== 'actions' }) : columns,
            
        });

        document.getElementById("rowCheckboxSelectAll").addEventListener("change", function (e) {
            const _ = this;
            dt.rows().every(function (rowIdx, tableLoop, rowLoop) {
                    const data = this.data();
                
                    data.selected = _.checked;
                    this.invalidate();
            })
            dt.draw(false);
        })

        tableEl.addEventListener('click', e => {
            const { target } = e;
            if (target.matches('.select-row')) {
                const row = dt.row(target.closest('tr'));
                const data = row.data();
                data.selected = target.checked;
                row.invalidate();

                const allRowData = dt.rows().data();
                const selectionRowData = allRowData.filter(r => r.selected === target.checked);
                const rowCheckboxSelectAll = document.getElementById("rowCheckboxSelectAll");


                if (allRowData.length === selectionRowData.length) {
                    rowCheckboxSelectAll.checked = target.checked;
                }
                else
                    rowCheckboxSelectAll.checked = false;

                dt.draw(false);
            }
        });
        const modalEl = document.getElementById("editRowModal");
        if(modalEl)
        {
            
            
            const modal = new bootstrap.Modal(modalEl);
            const form = modalEl.querySelector('form#editRowForm');
            await editStagingItemForm(dt, modal);
            modalEl.addEventListener("show.bs.modal", async (e) => {
                const url = form.dataset.get;
                const id = e.relatedTarget.dataset.id;

                const response = await fetch(`${url}?id=${id}`, {
                    method: 'get'
                });

                const data = await response.json();

                if(data)
                {
                    for (const key in data) {
                      if (data.hasOwnProperty(key)) {
                          const input = document.getElementById(toPascalCase(key));
                          if(!input) continue;
                          
                          try {
                              if(input.classList.contains('datepicker')) {
                                  
                                  datepickers.find(i => i.id === input.id).instance.setDate(data[key]);
                              }
                              else {
                                  input.value = data[key];
                              } 
                          } catch (e) {
                              console.error("Could not set value for " + input.id, e);
                          }                          
                      }
                    }
                    $(form).valid();
                }
                
            });
        }
    }
}