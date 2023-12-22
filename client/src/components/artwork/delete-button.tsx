"use client"

// import toast, { Toaster } from "react-hot-toast"
import { Icons } from "@/components/icons"

interface DeleteButtonProps {
  handler: () => void
  children: React.ReactNode
}

export function DeleteButton({ handler, children }: DeleteButtonProps) {
  const onClickHadler = () => {
    // toast("Si Funciono")
  }

  return (
    <form action={onClickHadler} className="w-full">
      <button
        className="text-danger-foreground bg-danger  flex w-full items-center justify-center gap-2 rounded-lg py-[10px] text-[14px] font-semibold leading-3 transition-all hover:opacity-80"
        type="submit"
      >
        <Icons.imageMinus className="h-5 w-5" />
        <span>{children}</span>
      </button>

      {/* <Toaster /> */}
    </form>
  )
}
