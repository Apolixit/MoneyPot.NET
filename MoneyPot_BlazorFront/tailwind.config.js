const colors = require('tailwindcss/colors');
module.exports = {
    content: [
        "./Pages/*.{html,js,razor,ts,md}",
        "./Pages/**/*.{html,js,razor,ts,md}",
        "./Shared/*.{html,js,razor,ts,md}",
        "./Shared/**/*.{html,js,razor,ts,md}",
    ],
    theme: {
        colors: {
            'main': '#16a34a', /* green-600 */
            'minor': '#fbbf24', /* amber-400 */
            'primary': colors.white,
            'secondary': '#f8fafc' /* gray-50 */
        }
    },
    variants: {
        extend: {},
    },
    plugins: [],
}