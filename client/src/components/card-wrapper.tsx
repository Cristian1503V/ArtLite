import { cn } from "@/libs/utils"

interface CardWrapperProps extends React.HTMLAttributes<HTMLDivElement> {
  children: React.ReactNode
}

export function CardWrapper({ children, className }: CardWrapperProps) {
  return (
    <div
      className={cn(className, "bg-aside flex flex-col gap-8 rounded-2xl p-8")}
    >
      {children}
    </div>
  )
}
