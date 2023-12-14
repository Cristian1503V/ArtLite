interface CardWrapperProps {
  children: React.ReactNode
}

export default function CardWrapper({ children }: CardWrapperProps) {
  return (
    <div className="bg-aside flex flex-1 flex-col gap-8 rounded-2xl p-8">
      {children}
    </div>
  )
}
