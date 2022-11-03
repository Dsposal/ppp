
import * as bootstrap from "bootstrap";
import Vivus from "vivus";
import Headroom from "headroom.js";
import noUiSlider from "nouislider";
import SmoothScroll from "smooth-scroll";
import 'datatables.net-bs5/css/dataTables.bootstrap5';
import 'datatables.net-bs5';
import '/node_modules/vanillajs-datepicker/sass/datepicker.scss';

"use strict";
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

async function packagesTable() {
    if(document.getElementById("packagesTable"))
    {
        const dt = $('#packagesTable').DataTable({
            
        });
    }
}