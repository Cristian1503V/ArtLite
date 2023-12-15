"use client"

import { useState } from "react"
import { cn } from "@/libs/utils"

interface ToggleTextProps {
  text?: string
}

export default function ToggleText({ text }: ToggleTextProps) {
  const [showText, setShowText] = useState(false)

  const handleOnClick = () => {
    setShowText((showText) => !showText)
  }

  return (
    <div>
      <span
        className={cn(
          "line-clamp-2 whitespace-pre-line text-[13px]",
          showText && "mb-2 line-clamp-none"
        )}
      >
        {text}
      </span>

      <button
        onClick={handleOnClick}
        className="text-secondary-foreground hover:text-muted-foreground text-[13px] font-bold underline transition-all"
      >
        {showText ? "Show less" : " Show more"}
      </button>
    </div>
  )
}
