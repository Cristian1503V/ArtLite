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
        input: {
          DEFAULT: "#101014",
          border: "#505054",
        },
        thumbnailContainer: "#000000",

        secondary: {
          DEFAULT: "",
          foreground: "#aaaaae",
        },
        muted: {
          DEFAULT: "#404044",
          foreground: "#e6e6ea",
          hover: "#505054",
        },

        accent: {
          DEFAULT: "#26bbff",
          foreground: "#101014",
          hover: "#74dafde8",
        },

        aside: {
          DEFAULT: "#202024",
        },

        tag: {
          DEFAULT: "#404044",
          foreground: "#e6e6ea",
        },

        danger: {
          DEFAULT: "hsl( 0 62.8% 30.6%)",
          foreground: "hsl( 0 0% 98%)",
        },
      },
    },
  },
  plugins: [require("tailwindcss-animated")],
}
export default config
