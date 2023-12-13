import type { Config } from "tailwindcss"

const config: Config = {
  content: [
    "./src/pages/**/*.{js,ts,jsx,tsx,mdx}",
    "./src/components/**/*.{js,ts,jsx,tsx,mdx}",
    "./src/app/**/*.{js,ts,jsx,tsx,mdx}",
  ],
  theme: {
    extend: {
      colors: {
        background: "#101014",
        foreground: "#ffff",
        input: "#331e3d",
        thumbnailContainer: "#000000",

        muted: {
          DEFAULT: "#404044",
          foreground: "#e6e6ea",
        },

        accent: {
          DEFAULT: "#13aff0",
          foreground: "#101014",
        },

        aside: {
          DEFAULT: "#202024",
        },
      },
    },
  },
  plugins: [require("tailwindcss-animated")],
}
export default config

