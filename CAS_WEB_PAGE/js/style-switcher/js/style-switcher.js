/* =============================================================================

* Template name : Ecada - Responsive Multipurpose Template
* Author : @encodeslife
* Version : v1.1.0
* Website: http://encodeslife.com
* Created : 22 November 2017
* Last update : 01 January 2018

============================================================================= */

var styleSwitcher = function() {
    return {
        //Style Switcher
        initStyleSwitcher: function() {
            var panel = $('.style-switcher');
            $('.style-switcher-btn').on('click', function() {
                panel.show();
            });
            $('.style-switcher-close').on('click', function() {
                panel.hide();
            });
            $('li', panel).on('click', function() {
                var color = $(this).attr('data-style');
                setColor(color);
                $('.list-unstyled li', panel).removeClass('theme-active');
                $(this).addClass('theme-active');
            });
            var setColor = function(color) {
                $('#skin').attr('href', 'css/theme-colors/' + color + '.css');
                $('.logo img').attr('src', 'img/themes/logo-' + color + '.png');
                $('.footer-logo').attr('src', 'img/themes/logo-' + color + '.png');
            }
        }
    };
}();