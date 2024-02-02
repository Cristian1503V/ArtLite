"use client"

// import toast, { Toaster } from "react-hot-toast"
import { useState } from "react"
import { useRouter } from "next/navigation"
import { deleteArwork } from "@/api/actions"
import { cn } from "@/libs/utils"
import { useFormStatus } from "react-dom"
import toast from "react-hot-toast"
import { useMutation, useQueryClient } from "react-query"

import { urls } from "@/config/urls"
import { Icons, Spiner } from "@/components/icons"

interface DeleteButtonProps {
  idArtwork: string
  idCreator: string
  slug: string
  children: React.ReactNode
}

export function DeleteButton({
  idArtwork,
  idCreator,
  slug,
  children,
}: DeleteButtonProps) {
  const [openModal, setOpenModal] = useState(false)
  const router = useRouter()

  const queryClient = useQueryClient()

  const { mutate, isLoading } = useMutation({
    mutationKey: ["Artwork", "idArtwork", idArtwork],
    mutationFn: () => deleteArwork(idArtwork),
    onError: () => {
      setOpenModal(false)
      toast.dismiss()
      toast.error(<b>Uh oh! Something went wrong.</b>, {
        className: "w-80 h-16 border-l-4  border-red-500 mt-14",
        duration: 3000,
        style: {
          backgroundColor: "#7f1d1d",
          color: "#fff",
        },
      })
    },
    onSuccess: () => {
      queryClient.invalidateQueries({
        queryKey: ["creator", "idCreator", idCreator],
      })
      router.push(urls.creator(slug))
      toast.dismiss()
      toast.success(<b>Artwork deleted successfully!</b>, {
        className: "w-80 h-16 border-l-4  border-green-500 mt-14",
        duration: 3000,
      })
    },
  })

  return (
    <form action={() => mutate()}>
      <button
        className="text-danger-foreground bg-danger flex w-full items-center justify-center gap-2 rounded-lg py-[10px] text-[14px] font-semibold leading-3 transition-all hover:opacity-80"
        type="button"
        onClick={() => setOpenModal(true)}
      >
        <Icons.imageMinus className="h-5 w-5" />
        <span>{children}</span>
      </button>

      <div
        className={cn(
          "bg-modal/90 animate-fade-right animate-duration-300 fixed inset-0 z-50 w-screen overflow-y-auto",
          openModal ? "block" : "hidden"
        )}
      >
        <div className="flex min-h-full items-end justify-center p-4 text-center sm:items-center sm:p-0">
          <div className="relative overflow-hidden rounded-md bg-white py-6 text-left shadow-xl transition-all sm:my-8 sm:w-full sm:max-w-lg">
            <div className="bg-white px-4 sm:p-6 sm:pb-4">
              <div className="sm:flex sm:items-start">
                <div className="mx-auto flex h-12 w-12 shrink-0 items-center justify-center rounded-full bg-red-100 sm:mx-0 sm:h-10 sm:w-10">
                  <Icons.alertTriangle className="text-red-500" />
                </div>
                <div className="mt-3 text-center sm:ml-4 sm:mt-0 sm:text-left">
                  <h3
                    className="text-base font-semibold leading-6 text-gray-900"
                    id="modal-title"
                  >
                    Delete Artwork
                  </h3>
                  <div className="mt-2">
                    <p className="text-sm text-gray-500">
                      Are you sure you want to delete this Artwork? All of your
                      data will be permanently removed. This action cannot be
                      undone.
                    </p>
                  </div>
                </div>
              </div>
            </div>
            <div className="bg-gray-50 px-4 py-3 sm:flex sm:flex-row-reverse sm:px-6">
              <button
                type="submit"
                disabled={isLoading}
                className={cn(
                  "inline-flex w-full justify-center rounded-md bg-red-600 px-3 py-2 text-sm font-semibold text-white shadow-sm hover:bg-red-500 sm:ml-3 sm:w-auto",
                  isLoading && "cursor-not-allowed bg-red-300 hover:bg-red-300"
                )}
              >
                {isLoading ? (
                  <>
                    <Spiner /> {"Processing..."}
                  </>
                ) : (
                  "Delete"
                )}
              </button>
              <button
                type="button"
                className="mt-3 inline-flex w-full justify-center rounded-md bg-white px-3 py-2 text-sm font-semibold text-gray-900 shadow-sm ring-1 ring-inset ring-gray-300 hover:bg-gray-50 sm:mt-0 sm:w-auto"
                onClick={() => setOpenModal(false)}
              >
                Cancel
              </button>
            </div>
          </div>
        </div>
      </div>
    </form>
  )
}
