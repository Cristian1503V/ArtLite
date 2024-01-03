interface TitleWrapperProps {
  title: string
  children: React.ReactNode
}

export function TitleWrapper({ title, children }: TitleWrapperProps) {
  return (
    <div className="flex flex-col px-4 py-6">
      <div className="rounded-t-md bg-[#303034] px-3 py-2">
        <span className="text-sm">{title}</span>
      </div>
      <div className="flex flex-col gap-2 rounded-b-md bg-[#18181c] p-4">
        {children}
      </div>
    </div>
  )
}
